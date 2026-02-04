using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private float respawnDelay = 0.5f; // seconds to wait before respawn

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"TriggerZone: OnTriggerEnter with '{other.gameObject.name}' (tag={other.gameObject.tag})");

        ProcessHit(other.gameObject);
    }

    // Fallback: if trap collider is not set as trigger, also handle normal collisions
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"TriggerZone: OnCollisionEnter with '{collision.gameObject.name}' (tag={collision.gameObject.tag})");
        ProcessHit(collision.gameObject);
    }

    private void ProcessHit(GameObject obj)
    {
        // First try to find a RollerBall component on the object itself or any parent.
        RollerBall player = obj.GetComponent<RollerBall>();
        if (player == null)
        {
            player = obj.GetComponentInParent<RollerBall>();
        }

        if (player == null)
        {
            Debug.Log("TriggerZone: no RollerBall component found on object or parents — ignoring.");
            return;
        }

        // Optional: ensure the root GameObject is tagged Player for clarity in the editor
        if (!player.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning($"TriggerZone: RollerBall found on '{player.gameObject.name}' but that GameObject is not tagged 'Player'. Proceeding anyway.");
        }

        if (player.RespawnPoint == null)
        {
            Debug.LogWarning("TriggerZone: player's RespawnPoint is not assigned.");
            return;
        }

        Debug.Log($"TriggerZone: triggering respawn for player '{player.gameObject.name}' (collider object: '{obj.name}') with delay {respawnDelay}s. Lives before: {player.Lives}");

        // Tell the player to handle the trap (it will decrement lives and respawn after delay)
        player.HandleTrap(respawnDelay);
    }
}

using System.Collections;
using UnityEngine;


public class RollerBall : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float speed = 50f; // réglable dans l'inspecteur — augmente la valeur pour aller plus vite
    [SerializeField] private int lives = 3; // number of lives the player has

    private Rigidbody rb;
    private bool isRespawning = false;
    
    public Transform RespawnPoint
    {
        get => respawnPoint;
    }

    public int Lives => lives;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called at a fixed timestep and is the correct place for physics updates
    void FixedUpdate()
    {
        if (rb == null) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move primarily left/right with keyboard; vertical input (forward/back) is kept if needed
        Vector3 direction = new Vector3(vertical, 0.0f, horizontal);

        // Use VelocityChange for snappy, mass-independent response (good for a fast roller ball)
        rb.AddForce(direction * speed, ForceMode.VelocityChange);
    }

    // Called by TriggerZone when the player hits a trap
    public void HandleTrap(float delay)
    {
        if (isRespawning) return;
        StartCoroutine(RespawnRoutine(delay));
    }

    private IEnumerator RespawnRoutine(float delay)
    {
        isRespawning = true;

        // decrement lives
        lives = Mathf.Max(0, lives - 1);
        Debug.Log($"RollerBall: hit trap — lives remaining: {lives}");

        // If no lives left, treat as game over
        if (lives <= 0)
        {
            Debug.Log("RollerBall: Game Over — no lives remaining.");

            // stop movement and disable the object
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Optionally you could show a Game Over UI here instead of deactivating
            gameObject.SetActive(false);

            yield break;
        }

        // wait the configured delay before respawning
        yield return new WaitForSeconds(delay);

        if (respawnPoint == null)
        {
            Debug.LogWarning("RollerBall: RespawnPoint not assigned. Cannot respawn.");
            isRespawning = false;
            yield break;
        }

        // Teleport to respawn point and reset physics so the ball doesn't keep previous velocity
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        isRespawning = false;
    }
}

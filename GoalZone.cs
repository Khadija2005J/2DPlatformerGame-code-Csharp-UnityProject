using UnityEngine;
using TMPro;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private Vector3 launchForce;

    private void OnCollisionEnter(Collision other)
    {
        // Use the collider's tag (Collision doesn't directly have CompareTag)
        if (!other.collider.CompareTag("Player"))
        {
            return;
        }
        Rigidbody rb = other.rigidbody;
        if (rb != null)
        {
            // Apply an impulse so the player is launched when reaching the goal
            rb.AddForce(launchForce, ForceMode.Impulse);
        }

        Debug.Log("YOU WIN!!!");
    }
public TextMeshProUGUI winText; // référence au texte “You Win !”

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TargetZone"))
        {
            Debug.Log("Bravo, vous avez gagné !");
            winText.gameObject.SetActive(true); // affiche le texte
        }
    }
}

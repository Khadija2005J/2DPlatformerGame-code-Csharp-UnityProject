using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            Debug.LogWarning("CameraTracker: 'player' Transform is not assigned on " + gameObject.name + ". Camera will not follow anything.");
            return;
        }

        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        transform.position = player.position + offset;
    }
}

using UnityEngine;

public class TeleportToNextLevel : MonoBehaviour
{
    [SerializeField] Explorer explorer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rigidbody))
        {
            explorer.LoadNextScene();
        }
    }
}

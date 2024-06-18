using UnityEngine;

public class TriggerForTV : MonoBehaviour
{
    [SerializeField] private PlayerFollower _animememe;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            StartCoroutine(_animememe.Falling(player));
        }
    }
}

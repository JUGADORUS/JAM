using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private RespawnShape _respawnShape;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            AudioManager.Instance.Sound.PlayOneShot(AudioManager.Instance.DeathClip);
            _respawnShape.SpawnInit(player.modelPlayer, _respawnShape.transform.position);
        }
    }
}

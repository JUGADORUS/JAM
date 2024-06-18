using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private RespawnShape respawnShape;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            AudioManager.Instance.Sound.PlayOneShot(AudioManager.Instance.DeathClip);
            respawnShape.SpawnInit(player.modelPlayer, respawnShape.transform.position);
        }
    }
}

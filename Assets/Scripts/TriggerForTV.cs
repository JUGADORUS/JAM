using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForTV : MonoBehaviour
{
    [SerializeField] Animememe animememe;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            StartCoroutine(animememe.Falling(player));
        }
    }
}

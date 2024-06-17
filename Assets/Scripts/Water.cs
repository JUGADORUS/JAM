using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private Explorer _explorer;

    private void OnTriggerEnter(Collider other)
    {
        if((other.TryGetComponent(out Sphere sphere )) || (other.TryGetComponent(out Rectangle rectangle)) || (other.TryGetComponent(out Triangle triangle)))
        {
            _explorer.Repit();
        }
    }
}

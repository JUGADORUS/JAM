using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private Explorer _explorer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Rigidbody rigidbody ))
        {
            _explorer.Repit();
        }
    }
}

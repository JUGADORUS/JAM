using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Triangle : Player
{
    private Transform parent;
    private float? difference;
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("IsMagnet"))
        {
            parent = collision.gameObject.transform;
            difference = transform.position.x - collision.transform.position.x;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            rigidbody.velocity = Vector3.zero;
        }
    }
    protected override void Jump()
    {
        if (parent != null)
        {
            parent = null;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
            difference = null;
            return;
        }
        base.Jump();
    }
    protected override void Move()
    {
        if (parent != null)
        {     
            Vector3 pos = parent.position - transform.position;
            pos.y = parent.position.y;
            pos.y -= (parent.localScale.y * 1.2f);
            transform.position = new Vector3(parent.position.x + difference.Value, pos.y, parent.position.z);
            return;
        }
        base.Move();
    }

}
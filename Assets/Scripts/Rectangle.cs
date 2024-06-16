using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : Player
{
    protected override void Move()
    {
        base.Move();
        //float angle = modelPlayer.speedRotation;
        //float direction = Input.GetAxisRaw("Horizontal");
        //////rigidbody.rotation = new Quaternion(0, 0, 0 * direction, 0);
        //transform.Rotate(new Vector3(0, 0, 90) * direction , Space.Self);
    }
}
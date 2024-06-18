using UnityEngine;

public class Triangle : Player
{
    private Transform _parent;
    private float? _difference;

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;

        if (collision.gameObject.layer == LayerMask.NameToLayer("IsMagnet"))
        {
            MagnetizeToObject(collision);
        }
    }

    private void MagnetizeToObject(Collision collision)
    {
        _parent = collision.gameObject.transform;
        _difference = transform.position.x - collision.transform.position.x;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    protected override void Jump()
    {
        if (_parent != null)
        {
            _parent = null;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
            _difference = null;

            return;
        }

        base.Jump();
    }

    protected override void Move()
    {
        if (_parent != null)
        {     
            Vector3 pos = _parent.position - transform.position;
            pos.y = _parent.position.y;
            pos.y -= (_parent.localScale.y * 1.2f);
            transform.position = new Vector3(_parent.position.x + _difference.Value, pos.y, _parent.position.z);

            return;
        }

        base.Move();
    }
}
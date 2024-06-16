using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public ModelPlayer modelPlayer;
    [SerializeField] private RespawnShape spawnShape;
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public Collider collider;
    public bool _isGrounded = true;

    public void Init(ModelPlayer model, RespawnShape respawnShape)
    {
        modelPlayer = model;
        spawnShape = respawnShape;
    }
    public virtual void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Move();
        if (Input.GetKeyDown(KeyCode.F))
        {
            spawnShape.Clone();
        }
    }

    protected virtual void Jump()
    {
        if (_isGrounded)
        {
            rigidbody.velocity = Vector3.up * modelPlayer.jumpForce;
            _isGrounded = false;
        }
    }
    protected virtual void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal") * modelPlayer.speed, rigidbody.velocity.y);
        rigidbody.velocity = moveInput;
    }
    

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public float speed;
    [SerializeField] public float jumpForce;

    public bool _isGrounded = true;

    private void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y);
        rigidbody.velocity = moveInput;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
            _isGrounded = false;
        }
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

    /* private void OnTriggerEnter(Collider other)
     {
         //if (other.CompareTag("Ground")
         if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
         {
             _isGrounded = true;
         }
     }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public ModelPlayer modelPlayer;
    [SerializeField] private RespawnShape spawnShape;
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public Collider collider;
    [SerializeField] public GameObject jumpEffect;
    [SerializeField] public GameObject jumpEffectToDelete;
    public MeshRenderer mesh;
    public bool _isGrounded = true;

    public void Init(ModelPlayer model, RespawnShape respawnShape, GameObject effectJump)
    {
        modelPlayer = model;
        spawnShape = respawnShape;
        jumpEffect = effectJump;
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
            AudioManager.Instance.Sound.PlayOneShot(AudioManager.Instance.JumpClip);
            rigidbody.velocity = Vector3.up * modelPlayer.jumpForce;
            _isGrounded = false;
            jumpEffectToDelete = Instantiate(jumpEffect, transform.position, Quaternion.identity);
            Destroy(jumpEffectToDelete, 2f);
        }
    }
    protected virtual void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal") * modelPlayer.speed, rigidbody.velocity.y);
        rigidbody.velocity = moveInput;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpEffectToDelete = Instantiate(jumpEffect, transform.position, Quaternion.identity);
            Destroy(jumpEffectToDelete, 2f);
        }
    }

    protected virtual void OnCollisionStay(Collision collision)
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

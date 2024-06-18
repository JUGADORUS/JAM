using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] public GameObject jumpEffect;

    private RespawnShape _spawnShape;
    private GameObject jumpEffectToDelete;
    public bool isGrounded = false;
    public ModelPlayer modelPlayer;
    public MeshRenderer mesh;

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
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Init(ModelPlayer model, RespawnShape respawnShape, GameObject effectJump)
    {
        modelPlayer = model;
        _spawnShape = respawnShape;
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
            _spawnShape.Clone();
        }
    }

    protected virtual void Jump()
    {
        if (isGrounded)
        {
            AudioManager.Instance.Sound.PlayOneShot(AudioManager.Instance.JumpClip);
            _rigidbody.velocity = Vector3.up * modelPlayer.jumpForce;
            isGrounded = false;
            jumpEffectToDelete = Instantiate(jumpEffect, transform.position, Quaternion.identity);
            Destroy(jumpEffectToDelete, 2f);
        }
    }

    protected virtual void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal") * modelPlayer.speed, _rigidbody.velocity.y);
        _rigidbody.velocity = moveInput;
    }
}

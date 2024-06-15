using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SOPlayer SOPlayer;
    public ModelPlayer modelPlayer;
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] private Transform spawnPos;

    public bool _isGrounded = true;

    private void Start()
    {
        modelPlayer = SOPlayer.modelPlayers[0];
        //Player prefab = Instantiate(modelPlayer.prefab, spawnPos.position, Quaternion.identity);
    }

    private void Update()
    {
        Jump();
        ChangeShape();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal") * modelPlayer.speed, rigidbody.velocity.y);
        rigidbody.velocity = moveInput;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rigidbody.AddForce(Vector3.up * modelPlayer.jumpForce);
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

    private void ChangeShape()
    {
        Player prefab = this;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            modelPlayer = SOPlayer.modelPlayers[0];
            CheckNotInit(prefab);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            modelPlayer = SOPlayer.modelPlayers[1];
            CheckNotInit(prefab);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            modelPlayer = SOPlayer.modelPlayers[2];
            CheckNotInit(prefab);
        }
    }

    private void CheckNotInit(Player prefab)
    {
        if (prefab == null)
        {
            prefab = Instantiate(modelPlayer.prefab, transform.position, Quaternion.identity);
        }
        else
        {
            Destroy(prefab.gameObject);
            prefab = Instantiate(modelPlayer.prefab, transform.position, Quaternion.identity);
        }
    }
}

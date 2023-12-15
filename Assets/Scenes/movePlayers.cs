using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayers : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 8.0f;
    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = 0.0f;
        float moveVertical = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1.0f;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Ïðûæîê
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
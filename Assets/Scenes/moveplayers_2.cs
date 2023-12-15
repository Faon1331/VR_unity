using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayers_2 : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 2.5f;
    [SerializeField] int maxJumps = 1; 
    [SerializeField] GameObject maincamera;
    [SerializeField] float jumpforce = 7f;

    bool isGrounded = true;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            maxJumps = 1; 
        }
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movement -= maincamera.transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += maincamera.transform.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement += maincamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= maincamera.transform.forward;
        }

        movement.Normalize();

        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        if (Input.GetKeyDown(KeyCode.Space) && maxJumps > 0)
        {
            //rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            maxJumps--;
        }
    }
}
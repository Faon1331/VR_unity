using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_tir : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "tir_wall")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Camera")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

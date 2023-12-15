using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveP : MonoBehaviour
{
    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >= 15)
        {
            speed = -speed;
        }
        if (transform.position.z <= 9)
        {
            speed = -speed;
        }
        Vector3 input = new Vector3(0, 0, 1);
        transform.position = transform.position + input * Time.deltaTime * speed;
    }
}

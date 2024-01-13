using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tir : MonoBehaviour
{
    public GameObject cube_tir;
    float timer = 3f;
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xCoord = Random.Range(23.5f,48.5f);
        float zCoord = Random.Range(39.2f,51.0f);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 3;
            GameObject spawnedObject = Instantiate(cube_tir);
            spawnedObject.transform.position = new Vector3(xCoord, 1.5f, zCoord);
            Destroy(spawnedObject, 10);
        }
    }
}

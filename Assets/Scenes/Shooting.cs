using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float firespeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(firebullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void firebullet(ActivateEventArgs Arg)
    {
        GameObject spawnbullet = Instantiate(bullet);
        spawnbullet.transform.position = spawnPoint.position;
        spawnbullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * firespeed;
        Destroy(spawnbullet, 5);
    } 
}

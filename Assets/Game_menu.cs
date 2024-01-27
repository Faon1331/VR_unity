using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game_menu : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2f;
    public GameObject menu;
    public InputActionProperty showbutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showbutton.action.WasPressedThisFrame() )
        {
            menu.SetActive(!menu.activeSelf);

            menu.transform.position = head.position + new Vector3(head.forward.x, head.forward.y, head.forward.z).normalized * spawnDistance;
        }
        menu.transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
        menu.transform.forward *= -1;
    }
}

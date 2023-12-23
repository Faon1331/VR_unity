using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class hand_animator : MonoBehaviour
{
    public InputActionProperty pichanimation1;
    public Animator pich;
    public InputActionProperty pichanimation2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pichanimation1.action.ReadValue<float>();
        pich.SetFloat("Trigger", triggerValue);
        float gripValue = pichanimation2.action.ReadValue<float>();
        pich.SetFloat("Grip", gripValue);
    }
}

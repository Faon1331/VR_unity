using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class vibr : MonoBehaviour
{
    [Range(0, 1)]
    public float intence;
    public float dyration;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(triggerhubtik) 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void triggerhubtik(XRBaseController controller) 
    {
        if (intence > 0)
            controller.SendHapticImpulse(intence, dyration);
    }
    public void triggerhubtik(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor) 
            triggerhubtik(controllerInteractor.xrController);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class setturn : MonoBehaviour
{
    public ActionBasedContinuousTurnProvider conturn;
    public ActionBasedSnapTurnProvider snapturn;

    public void settype (int index)
    {
        if(index == 0)
        {
            snapturn.enabled = true;
            conturn.enabled = false;
        }
        else if (index == 1)
        {
            snapturn.enabled = false;
            conturn.enabled = true;
        }
    }
}

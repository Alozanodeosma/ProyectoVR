using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableAttach : XRGrabInteractable
{

    public Transform leftAttatchTransform;
    public Transform rightAttatchTransform;
    // Start is called before the first frame update
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        if (args.interactorObject.transform.CompareTag("leftHand"))
        {
            //Debug.Log("left");
            attachTransform= leftAttatchTransform;
        }else if(args.interactorObject.transform.CompareTag("rightHand"))
        {
            //Debug.Log("ight");
            attachTransform = rightAttatchTransform;
        }
        base.OnSelectEntered(args);
    }
}

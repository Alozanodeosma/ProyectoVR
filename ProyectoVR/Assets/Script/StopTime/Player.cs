﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.ImageEffects;
public class Player : MonoBehaviour
{
    private TimeManager timemanager;
    public GrayscaleLayers Grayscale;

    private InputAction myAction;
    private InputAction myAction2;
    [Space][SerializeField] private InputActionAsset myActionsAsset;
    // Start is called before the first frame update
    void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        myAction = myActionsAsset.FindAction("XRI RightHand/StopTime");
        myAction2 = myActionsAsset.FindAction("XRI LeftHand/PlayTime");

    }

    // Update is called once per frame
    void Update()
    {
        if (myAction.WasPerformedThisFrame())
        {
            Debug.Log("PULSADO PAusa");
            timemanager.StopTime();
            Grayscale.enabled = true;
        }

        if (myAction2.WasPerformedThisFrame() && timemanager.TimeIsStopped)  //Continue Time when E is pressed
        {
            Debug.Log("PULSADO Play");
            timemanager.ContinueTime();
            Grayscale.enabled = false;

        }

        /*
        if(Input.GetKeyDown(KeyCode.Q)) //Stop Time when Q is pressed
        {
            timemanager.StopTime();
            Grayscale.enabled = true;
        }
        if(Input.GetKeyDown(KeyCode.E) && timemanager.TimeIsStopped)  //Continue Time when E is pressed
        {
            timemanager.ContinueTime();
            Grayscale.enabled = false;

        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.ImageEffects;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private TimeManager timemanager;
    private GameObject rayGrab;
    public GrayscaleLayers Grayscale;


    public TextMeshProUGUI playButton;
    public TextMeshProUGUI stopButton;

    public static bool Play = true;
    private InputAction myAction;
    private InputAction myAction2;
    private InputAction GrabGun;
    [Space][SerializeField] private InputActionAsset myActionsAsset;
    // Start is called before the first frame update
    void Start()
    {
        //canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        stopButton.enabled = false;
        playButton.enabled = false;
        //playButton = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<TextMeshProUGUI>();
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        myAction = myActionsAsset.FindAction("XRI RightHand/StopTime");
        myAction2 = myActionsAsset.FindAction("XRI LeftHand/PlayTime");
        GrabGun = myActionsAsset.FindAction("XRI RightHand/GrabGun");
        //rayGrab = GameObject.FindGameObjectWithTag("leftHand");

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            EnemySpawner.enemigosDerrotados = 0;
        }
        //if (GrabGun.WasPerformedThisFrame())
        //{
        //    rayGrab.SetActive(false);
        //}

        /*
        if (myAction.WasPerformedThisFrame())
        {
            playButton.enabled= false;
            stopButton.enabled= true;

            //canvas.enabled= true;
            Play = false;
            //Debug.Log("PULSADO PAusa");
            timemanager.StopTime();


            //Grayscale.enabled = true;
        }

        if (myAction2.WasPerformedThisFrame() && timemanager.TimeIsStopped)  //Continue Time when E is pressed
        {
            playButton.enabled = true;
            stopButton.enabled = false;
            Play = true;
            //Debug.Log("PULSADO Play");
            timemanager.ContinueTime();
            //Grayscale.enabled = false;

        }
        */


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

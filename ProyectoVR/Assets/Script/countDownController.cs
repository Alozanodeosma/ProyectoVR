using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class countDownController : MonoBehaviour
{
    public int countDownTime;
    private float amountTime;
    private int truncalTime;
    public TextMeshProUGUI cuntDisplay;

    [SerializeField]
    public GameObject leftHand;
    [SerializeField]
    public GameObject rightHand;

    private TimeManager timemanager;
    public TextMeshProUGUI prepButton;

    private void Start()
    {
        //Time.timeScale = 0;
        amountTime = countDownTime;
        //StartCoroutine(CountDownToStart());

        leftHand = GameObject.FindGameObjectWithTag("leftHand");
        rightHand = GameObject.FindGameObjectWithTag("rightHand");
        leftHand.SetActive(false);
        rightHand.SetActive(false);


        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        prepButton.enabled = false;

    }
    private void Update()
    {

        amountTime -= Time.unscaledDeltaTime;
        truncalTime = (int)amountTime;
        cuntDisplay.text = truncalTime.ToString();
        if (amountTime < 1)
        {
            //Time.timeScale = 1f;
            cuntDisplay.text = "Go!";
            Invoke("RemoveText", 1f);
            leftHand.SetActive(true);
            rightHand.SetActive(true);

            Player.Play = false;
            prepButton.enabled = true;
            timemanager.StopTime();


        }
        /*
        if (Time.timeScale == 0f) // Si el Time Scale es 0
        {
            amountTime -= Time.unscaledDeltaTime;
            truncalTime = (int)amountTime;
            //Debug.Log(truncalTime);

            cuntDisplay.text = truncalTime.ToString();

            if(amountTime <1)
            {
                Time.timeScale = 1f;
                cuntDisplay.text = "Go!";
                Invoke("RemoveText", 1f);
            }

        }
        */



    }
    private void RemoveText()
    {
        cuntDisplay.text = "";
        enabled = false;
    }
    /*
    IEnumerator CountDownToStart()
    {
        while(countDownTime > 0)
        {
            cuntDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        cuntDisplay.text = "Go!";

        //GameController.instance.BeginGame();

        

        yield return new WaitForSeconds(1f);

        cuntDisplay.gameObject.SetActive(false);
    }*/
}

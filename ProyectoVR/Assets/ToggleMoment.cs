using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMoment : MonoBehaviour
{
    public GameObject teleport;
    public Toggle selectToggle;
    // Start is called before the first frame update
    // Update is called once per frame

    void Start()
    {
        selectToggle.isOn = false; 
    }
    void Update()
    {
        if (selectToggle.isOn)
        {

            teleport.SetActive(true);
        }
        else
        {
            teleport.SetActive(false);
        }
    }
}

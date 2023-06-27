using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    SphereCollider Claymore;
    public MeshRenderer ClaymoreVisible;
    public GameObject Exp;

    // Start is called before the first frame update
    void Start()
    {
        Claymore= GetComponent<SphereCollider>();
        //ClaymoreVisible = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(handButton.Explotar == true)
        {
            Claymore.radius = 15;
            Exp.SetActive(true);
            ClaymoreVisible.GetComponent<MeshRenderer>().enabled = false;
        }
        
    }
}

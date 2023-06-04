using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnMovimiento : MonoBehaviour
{
    public GameObject direccionBala;
    public GameObject bala;
    public float velocidadBala=2f;

    public float fireRate = 0.5f;
    private float lastShot;

    private void Start()
    {
        lastShot = Time.time;
    }
    public void dispararBala()
    {
        if (lastShot< Time.time)
        {
            lastShot= Time.time + fireRate;
            var balaD = Instantiate(bala, direccionBala.transform.position, direccionBala.transform.rotation * Quaternion.Euler(90, 0, 0));
            balaD.GetComponent<Rigidbody>().velocity = transform.forward * velocidadBala;
        }
       
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoBala : MonoBehaviour
{

    public float tiempoDesaparicion=4;
    public void Awake()
    {
        Destroy(gameObject, tiempoDesaparicion);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tarjet")
        {
            Debug.Log("Trieger");
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tarjet")
        {
            Debug.Log("collider");
            Destroy(collision.gameObject);
        }
    }
}

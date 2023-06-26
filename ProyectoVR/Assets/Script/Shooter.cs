using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    /*
    void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tarjet")
        {
            Debug.Log("hola");
            Destroy(collision.gameObject);
        }
    }
    */

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tarjet")
        {
            Debug.Log("Trieger");
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            EnemySpawner.enemigosDerrotados++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tarjet")
        {
            Debug.Log("collider");
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            EnemySpawner.enemigosDerrotados++;


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tarjet")
        {
            Debug.Log("hola");
            Destroy(collision.gameObject);
        }
    }
}

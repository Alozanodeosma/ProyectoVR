using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class LookAt : MonoBehaviour
{
    public Transform Player;

    private void Start()
    {
        if(Player == null)
        {
            Player = FindObjectOfType<InputActionManager>().gameObject.transform;
        }
        transform.LookAt(new Vector3(Player.transform.position.x,transform.position.y, Player.transform.position.z));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Player;

    private void Start()
    {
        
        transform.LookAt(new Vector3(Player.transform.position.x,transform.position.y, Player.transform.position.z));
    }
}

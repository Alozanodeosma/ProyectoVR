using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitForSexBalls : MonoBehaviour
{
    [SerializeField]
    GameObject bala;
    private float timer = 0f;
    public float offsetTime = 2f;
    private void Update()
    {
        if (bala.active)
        {
            timer += Time.deltaTime;
            if (timer > offsetTime)
            {
                timer = 0f;
                bala.SetActive(false);
            }
        }
    }
}

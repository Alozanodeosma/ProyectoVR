using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=ydjpNNA5804 #video tutorial usado

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCunt;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCunt<4)
        {
            xPos = Random.Range(0, 4);
            zPos = Random.Range(0, 4);
            Instantiate(theEnemy, new Vector3(xPos, 0.50f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2);
            enemyCunt++;
        }
    }
}

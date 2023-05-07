using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//https://www.youtube.com/watch?v=ydjpNNA5804 #video tutorial usado

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    [SerializeField] private float timeSpawn = 2;
    

    public int enemyCunt;
    public int distance = 4;
    public int minDist = 2;


    //solo funciona character en 0
    // Start is called before the first frame update
    void Start()
    {
        if (minDist > distance)
        {
            Debug.LogError("Distancia minima menor que maxima");
        }
        else
        {
            StartCoroutine(EnemyDrop());
        }
       
    }
    IEnumerator EnemyDrop()
    {

        for(int i = 0; i<enemyCunt;i++)
        {

            do
            {
                xPos = Random.Range(-distance, distance);
                zPos = Random.Range(-distance, distance);
            } while (xPos >= -minDist && xPos <= minDist && zPos >= -minDist && zPos <= minDist);

            Instantiate(theEnemy, new Vector3(xPos, 0.50f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(timeSpawn);
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(distance, 0, distance)*2);

        if (minDist>distance)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(minDist, 0, minDist)*2);
    }
}

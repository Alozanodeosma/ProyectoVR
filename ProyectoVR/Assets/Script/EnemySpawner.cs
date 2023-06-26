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
    private TimeManager timemanager;

    public Canvas canvasWin;

    public static int enemigosDerrotados = 0;

    public int enemyCunt;
    public int distance = 4;
    public int minDist = 2;
    bool firstTime = true;
    private int[] xPosArray;
    private int[] zPosArray;


    public AudioSource source;
    public AudioClip Win;

    List<GameObject> list = new List<GameObject>();
    //solo funciona character en 0
    // Start is called before the first frame update
    public void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        if (firstTime)
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
        else
        {
            StartCoroutine(EnemyPlace());
        }

    }

    public void Update()
    {
        if (enemigosDerrotados >=enemyCunt)
        {
            Debug.Log("U WIN");
            canvasWin.gameObject.SetActive(true);
            source.PlayOneShot(Win);
            enemigosDerrotados = 0;
        }
    }


    IEnumerator EnemyPlace()
    {
        timemanager.ContinueTime();
        Player.Play = true;
        foreach (GameObject item in list)
        {
            item.SetActive(true);
            yield return new WaitForSeconds(0);
        }
       
    }

    IEnumerator EnemyDrop()
    {
        int[] xPosArray = new int[enemyCunt];
        int[] zPosArray = new int[enemyCunt];


        for (int i = 0; i<enemyCunt;i++)
        {

            do
            {
                xPos = Random.Range(-distance, distance);
                
                zPos = Random.Range(-distance, distance);
                
            } while (xPos >= -minDist && xPos <= minDist && zPos >= -minDist && zPos <= minDist);
            xPosArray[i] = xPos;
            zPosArray[i] = zPos;
            list.Add(Instantiate(theEnemy, new Vector3(xPos, 0.6f, zPos), Quaternion.identity));
            yield return new WaitForSeconds(timeSpawn);
        }

        firstTime = false;
        yield return new WaitForSeconds(timeSpawn);


        foreach (GameObject item in list){
            item.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float delay = 1f;
    private float timer = 0f;
    private int number = 0;
    public GameObject P1, P2;
    public GameObject enemyPrefab;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(timer<delay)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(0f,0.5f,-18f),Quaternion.identity);
            EnemySc ensc = newEnemy.GetComponent<EnemySc>();
           // ensc.Player1 = P1;
           // ensc.Player2 = P2;
            if(number%2==0)
            {
                ensc.target = P1;
            }
            else
            {
                ensc.target = P2;
            }
            number++;
        }
    }
}

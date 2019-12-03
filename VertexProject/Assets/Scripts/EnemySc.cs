using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySc : MonoBehaviour
{
    private NavMeshAgent navm;
    public GameObject target;

    //public GameObject Player1, Player2;

    void Start()
    {
        navm = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
         navm.SetDestination(target.transform.position);
    }
}

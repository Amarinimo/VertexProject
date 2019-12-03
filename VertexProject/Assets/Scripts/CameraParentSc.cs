using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParentSc : MonoBehaviour
{
    public GameObject P1, P2;
    void Start()
    {
        
    }


    void Update()
    {
        if(P1!=null&&P2!=null)
        transform.position = new Vector3((P1.transform.position.x + P2.transform.position.x) / 2, transform.position.y, (P1.transform.position.z + P2.transform.position.z) / 2);
    }
}

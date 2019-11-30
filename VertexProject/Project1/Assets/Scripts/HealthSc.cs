using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSc : MonoBehaviour
{
    public float health = 1f;
    void Start()
    {
        
    }


    void Update()
    {
        if(health<=0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            health -= Time.deltaTime;
        }
    }
}

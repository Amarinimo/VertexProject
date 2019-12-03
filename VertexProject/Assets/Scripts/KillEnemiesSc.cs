using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemiesSc : MonoBehaviour
{
    public bool KillingLicense = true;
    public bool boolet = false;
    public float timeYet = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        if(boolet)
        {
            timeYet -= Time.deltaTime;
            if(timeYet<=0f)
            {
                Destroy(gameObject);
            }
        } 
    }
    private void OnCollisionStay(Collision collision)
    {

        if (KillingLicense && collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
        }
    }

}

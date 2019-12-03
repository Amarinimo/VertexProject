using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwordSc : MonoBehaviour
{
    public KeyCode attackKey;
    public float delay = 2f;
    public Animator anim;
    public float killingCooldown = 0.8f;

    private float timer;
    private KillEnemiesSc ksc;
    void Start()
    {
        ksc = GetComponent<KillEnemiesSc>();
        ksc.KillingLicense = false;
    }

    void Update()
    {
        if(Input.GetKey(attackKey))
        {
            if(timer>=delay)
            {
                ksc.KillingLicense = true;
                anim.SetTrigger("Attack");
                timer = 0f;
            }
        }
        if (timer < delay)
        {
            timer += Time.deltaTime;
            if (timer > killingCooldown)
            {
                ksc.KillingLicense = false;
            }
            else
            {
                ksc.KillingLicense = true;
            }
        }
       

    }
}

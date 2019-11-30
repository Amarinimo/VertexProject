using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShootingSc : MonoBehaviour
{
    public float booletspeed = 900f;
    public GameObject bullet;
    public KeyCode shootKey;
    public float delay = 2f;
    public Animator anim;

    public SimpleMoveSc mamoGdzieIdziesz;

    private float timer;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(shootKey))
        {
            if (timer >= delay)
            {
                anim.SetTrigger("Shoot");
                GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, 0.28f, transform.position.z), Quaternion.identity);
                KillEnemiesSc ksc = newBullet.GetComponent<KillEnemiesSc>();
                ksc.boolet = true;
                Rigidbody rb = newBullet.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(mamoGdzieIdziesz.facingDirection.x * booletspeed, 0f, mamoGdzieIdziesz.facingDirection.y * booletspeed);
                timer = 0f;
            }
        }
        if (timer < delay)
        {
            timer += Time.deltaTime;
        }

    }
}

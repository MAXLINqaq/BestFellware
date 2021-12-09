using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public float currentTime = 1f;
    public GameObject Bullet;
    public bool isRinging = false;
    public AudioSource As;

    public bool shoot = false;
    private float invokeTime;
    private bool firstShoot;

    private void Awake()
    {
        firstShoot = true;
    }

    void Update()
    {
        invokeTime += Time.deltaTime;
        if (firstShoot)
        {
            FirstShoot();
        }
        Shoot();

    }
    private void FirstShoot()
    {
        if (shoot == true)
        {

            Instantiate(Bullet, transform.position - new Vector3(0, 0, transform.position.z), transform.rotation);
            if (!As.isPlaying)
            {
                As.Play();
            }
            shoot = false;
            firstShoot = false;
        }
    }
    private void Shoot()
    {
        if (shoot == true)
        {
            if (invokeTime - currentTime > 0)
            {

                if (isRinging == false)
                {
                    Instantiate(Bullet, transform.position - new Vector3(0, 0, transform.position.z), transform.rotation);
                    if (!As.isPlaying)
                    {
                        As.Play();
                    }
                }
                invokeTime = 0;
                shoot = false;
            }
            else
            {
                shoot = false;
            }
        }
    }
    public void Generate()
    {
        shoot = true;
    }
}

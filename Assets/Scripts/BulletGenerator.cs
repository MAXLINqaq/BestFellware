using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public float currentTime = 1f;
    public GameObject Bullet;
    public bool isRinging = false;

    private float invokeTime;

    private void Start()
    {
            Instantiate(Bullet, transform.position - new Vector3(0, 0, transform.position.z), transform.rotation);
    }

    void Update()
    {
        invokeTime += Time.deltaTime;

        if (invokeTime - currentTime > 0)
        {
            if (isRinging == false)
            {
                Instantiate(Bullet, transform.position - new Vector3(0, 0, transform.position.z), transform.rotation);
            }
            invokeTime = 0;
        }

    }
}

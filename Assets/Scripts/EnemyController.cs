using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1;
    public int moveFace = 1;
    public float leftWall = -5;
    public float rightWall = 8;

    private float invokeTime;
    public float currentTime = 0.5f;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        invokeTime += Time.deltaTime;

        if (invokeTime - currentTime > 0)
        {
            Move();
            invokeTime = 0;
        }
      
    }
    private void Move()
    {
        if (moveFace == 1)
        {
            transform.position = transform.position + new Vector3(Time.deltaTime * speed, 0, 0);
            if (transform.position.x > rightWall)
            {
                moveFace = 0;
                transform.position = transform.position - new Vector3(0, 0.6f, 0);
            }
        }
        else
        {
            transform.position = transform.position + new Vector3(Time.deltaTime * speed *-1, 0, 0);
            if (transform.position.x < leftWall)
            {
                moveFace = 1;
                transform.position = transform.position - new Vector3(0, 0.6f, 0);
            }
        }
    }
}

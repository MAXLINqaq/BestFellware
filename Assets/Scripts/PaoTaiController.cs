using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaoTaiController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Joystick joystick;
    public float speed;

    void Update()
    {
        rb.velocity = new Vector2(joystick.Horizontal * speed, 0);
    }
}

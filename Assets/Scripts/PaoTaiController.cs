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
        if (transform.position.x >= -6.78 || transform.position.x <= 6.64)
        {
            rb.velocity = new Vector2(joystick.Horizontal * speed, 0);
        }
        if (transform.position.x < -6.78 && joystick.Horizontal >0)
        {
            rb.velocity = new Vector2(joystick.Horizontal * speed, 0);
        }
        if (transform.position.x > 6.64 && joystick.Horizontal < 0)
        {
            rb.velocity = new Vector2(joystick.Horizontal * speed, 0);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Joystick joystick;
    public float speed ;
    
    // Update is called once per frame
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        // rb.velocity = new Vector2 (joystick.Horizontal*speed , joystick.Vertical*speed ) ;
        rb.velocity = new Vector2(joystick.Horizontal * speed, 0);
        if (joystick.Horizontal > 0)
        {
            transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
        }
        else if (joystick.Horizontal < 0)
        {
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
        }
    }
}

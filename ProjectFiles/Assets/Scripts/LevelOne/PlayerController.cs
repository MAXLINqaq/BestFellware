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
        rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical*speed);

    }
}

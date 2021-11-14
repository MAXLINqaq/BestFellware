using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaoTaiController : MonoBehaviour
{
    // Start is called before the first frame update
    public Joystick joystick;
    public float speed;

    void Update()
    {
        if (joystick.Horizontal != 0)
        {
            if (transform.position.x < 6.5 && transform.position.x > -6.5)
            {
                transform.position = transform.position + new Vector3(joystick.Horizontal * speed * Time.deltaTime, 0, 0);
            }          
            if (transform.position.x < -6.5 && joystick.Horizontal > 0)
            {
                transform.position = transform.position+ new Vector3(joystick.Horizontal * speed * Time.deltaTime, 0, 0);
            }
            if (transform.position.x > 6.5 && joystick.Horizontal < 0)
            {
                transform.position = transform.position+ new Vector3(joystick.Horizontal * speed * Time.deltaTime, 0, 0);
            }
        }
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CuiDengController : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;



    public Light2D light12D;
    public Light2D light22D;




    // Start is called before the first frame update
    void Update()
    {
        if (transform.position.y > 1)
        {
            light12D = light1.GetComponent<Light2D>();
            light22D = light2.GetComponent<Light2D>();
            light12D.intensity = 0.2f;
            light22D.intensity = 1f;

        }
    }
    public void TurnOffLight()
    {
        light12D = light1.GetComponent<Light2D>();
        light22D = light2.GetComponent<Light2D>();
        light12D.intensity = 0.2f;
        light22D.intensity = 1f;
    }

}

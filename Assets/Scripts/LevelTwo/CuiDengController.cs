using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CuiDengController : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;


    private Light2D light12D;
    private Light2D light22D;
    private Light2D light32D;

    Color color =new Color(187f,255f,163f,1f);

    // Start is called before the first frame update
    void Update()
    {
        if (transform.position.y > 4)
        {
            light12D = light1.GetComponent<Light2D>();
            light22D = light2.GetComponent<Light2D>();
            light32D = light3.GetComponent<Light2D>();
            light12D.intensity = 0.2f;
            light22D.intensity = 1f;
            light32D.color = color;
        }
    }
}

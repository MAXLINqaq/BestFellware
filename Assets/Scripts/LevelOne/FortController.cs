using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortController : MonoBehaviour
{
    public int hitCount;
    public Text text;
    public GameObject Bullet;
    public string[] Str ;
    public float[]  currentTime ;
    public  float invokTime=0;

    void Update()
    {

        if (hitCount >= 3)
        {
            Destroy(this.gameObject);
            text.text = "";
        }
        else
        {
            text.text = Str[hitCount];
        }
        invokTime += Time.deltaTime;
        if (invokTime > currentTime[hitCount])
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 5, transform.position.z), transform.rotation);
            invokTime = 0;
        }
    }
}

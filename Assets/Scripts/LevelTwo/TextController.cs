using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    private float invokeTime;

    private string Str = "中国人民志愿军万岁！第七连永垂不朽！";
    private int i=0;
    // Update is called once per frame
    void Update()
    {
        invokeTime += Time.deltaTime;
        if (invokeTime > 0.8)
        {
            i++;
            invokeTime = 0;
        }
        text.text = Str.Substring(0, i);
    }
}

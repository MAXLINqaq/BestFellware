using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    private float invokeTime;

    public  string Str = "中国人民志愿军万岁!第七连永垂不朽!";
    private int i=0;
    // Update is called once per frame
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        invokeTime += Time.deltaTime;
        if (invokeTime > 1.2)
        {
            i++;
            invokeTime = 0;
        }
        if (i < Str.Length)
        {
            text.text = Str.Substring(0, i);
        }
    }
}

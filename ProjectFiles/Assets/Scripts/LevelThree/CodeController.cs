using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CodeController : MonoBehaviour
{
    public  Joystick joystick;
    public float speed;
    public int[] password;
    public AudioSource AudioA;
    public AudioSource AudioB;
    public AudioSource AudioC;

    public  float angleCount;

    public  int i;
    public  int j;
    public int promptCount;//��¼��ʾ
    private bool gotPd;//�Ѿ��������


    // Start is called before the first frame update
    void Awake()
    {
        i = 1;
        j = 0;
        promptCount = 0;
        gotPd = false;

    }

    // Update is called once per frame
    void Update()
    {
        angleCount += joystick.Horizontal * speed * Time.deltaTime;
        transform.Rotate(0, 0, joystick.Horizontal * speed* Time.deltaTime);
        if (angleCount < i * 22.5 + 0.2 && angleCount >  i  * 22.5 - 0.2)
        {
            if (joystick.Horizontal > 0)
            {
                i++;
                if (password[j] == i-1)
                {
                    AudioB.Play();
                    gotPd = true;
                }
                else
                {
                    gotPd = false;
                    AudioA.Play();
                }
            }
            if (i == 17)
            {
                i = 0;
                angleCount = 0;
                promptCount++;
            }
        }
        if (gotPd && joystick.Horizontal < 0 && angleCount < 0.2 && angleCount > -0.2)
        {
            AudioC.Play();
            gotPd = false;
            i = 0;
            j++;
        }
        if (promptCount == 3)
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            flowchart.ExecuteBlock("Game2");
            promptCount++;
        }
        if (j == 4)
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            flowchart.ExecuteBlock("D3");
        }
    }
}

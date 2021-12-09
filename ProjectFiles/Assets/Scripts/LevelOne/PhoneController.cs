using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PhoneController : MonoBehaviour
{
    public GameObject FaSong;
    public  int RingingCount =0 ;
    public GameObject LaiDian1;
    public GameObject LaiDian2;
    public AudioSource As;


    public float currentTime = 3f;
    private float invokeTime;

    void Update()
    {
        invokeTime += Time.deltaTime;

        if (invokeTime - currentTime > 0)
        {
            FaSong.GetComponent<BulletGenerator>().isRinging=true;
            if (RingingCount < 2)
            {
                LaiDian1.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            }
            else
            {
                LaiDian2.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            }

            if ( !As.isPlaying)
            {
                As.Play();
            }

        }
        if (RingingCount > 2)
        {
            ExecuteNow();
        }
    }
    private void ExecuteNow()
    {
        Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        flowchart.ExecuteBlock ("part2");
    }
    public void SetInvokeTime()
    {
        if (invokeTime - currentTime > 0)
        { 
            FaSong.GetComponent<BulletGenerator>().isRinging = false;

            LaiDian1.transform.localScale = new Vector3(1.5f, 0, 1);
            invokeTime = 0;
            RingingCount++;
            if (As.isPlaying)
            {
                As.Stop();
            }
        }
    }
}

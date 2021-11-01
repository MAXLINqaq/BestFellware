using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PhoneController : MonoBehaviour
{
    public GameObject FaSong;
    public  int RingingCount =0 ;


    public float currentTime = 3f;
    private float invokeTime;

    void Update()
    {
        invokeTime += Time.deltaTime;

        if (invokeTime - currentTime > 0)
        {
            FaSong.GetComponent<BulletGenerator>().isRinging=true;  
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
        FaSong.GetComponent<BulletGenerator>().isRinging = false;
        invokeTime = 0;
        RingingCount++;
    }
}

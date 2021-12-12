using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PickLockController : MonoBehaviour
{
    public int UnlockCount;
    public GameObject RotationPhone;
    public bool isEnd;
    public bool ExecuteOver;
    // Start is called before the first frame update
    void Awake()
    {
        isEnd = false;
        UnlockCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (UnlockCount >= 6)
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            if (!isEnd)
            {
                flowchart.ExecuteBlock("Game1end");
                isEnd = true;
            }
            if (ExecuteOver)
            {
                if (RotationPhone.GetComponent<gyrocope>().a.y < -200)
                {
                    flowchart.ExecuteBlock("D2");
                }
            }
        }
    }
    public void isExecuteOver()
    {
        ExecuteOver = true;
    }

}

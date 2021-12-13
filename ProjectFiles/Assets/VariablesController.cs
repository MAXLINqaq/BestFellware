using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class VariablesController : MonoBehaviour
{
    void Start()
    {
        Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        if (PlayerPrefs.GetInt("progress") == 1)
        {
            flowchart.SetIntegerVariable("Times", 0);
        }
        else if (PlayerPrefs.GetInt("progress") == 3)
        {
            flowchart.SetIntegerVariable("Times", 1);
        }
        else if (PlayerPrefs.GetInt("progress") == 5)
        {
            flowchart.SetIntegerVariable("Times", 2);
        }
        flowchart.ExecuteBlock("BlockExcuter");
    }
}

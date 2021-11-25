using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class DialoguesExecuter : MonoBehaviour
{

    public GameObject[] DontDestroyObjects;
    private static bool isExist;
    private bool isFirstTime = true ;
    private bool isLevelOneFail ;
    // Start is called before the first frame update
    private void Awake()
    {
         DontDestory();
         ExecuteNow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ExecuteNow()
    {
        Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        if (isFirstTime)
        {
            flowchart.ExecuteBlock("D1");
        }
        if (isLevelOneFail)
        {
            flowchart.ExecuteBlock("D2");
        }
        
    }
    private void DontDestory()
    {
        if (!isExist)
        {
            for (int i = 0; i < DontDestroyObjects.Length; i++)
            {
                DontDestroyOnLoad(DontDestroyObjects[i]);
            }
            isExist = true;
        }
        else
        {
            for (int i = 0; i < DontDestroyObjects.Length; i++)
            {
                Destroy(DontDestroyObjects[i]);
            }
        }
    }
}

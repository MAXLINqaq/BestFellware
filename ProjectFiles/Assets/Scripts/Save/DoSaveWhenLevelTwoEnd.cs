using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSaveWhenLevelTwoEnd : MonoBehaviour
{
    public void Save()
    {
        PlayerPrefs.SetInt("progress",3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSaveWhenLevelThreeEnd : MonoBehaviour
{
    public void Save()
    {
        PlayerPrefs.SetInt("progress",5);
    }
}

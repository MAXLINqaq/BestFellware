using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSaveWhenLevelOneDone : MonoBehaviour
{
    public void Save()
    {
        PlayerPrefs.SetInt("progress",1);
    }
}

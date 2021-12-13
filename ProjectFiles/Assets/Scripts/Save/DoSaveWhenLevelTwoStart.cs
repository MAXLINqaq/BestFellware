using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSaveWhenLevelTwoStart : MonoBehaviour
{
    // Start is called before the first frame update
    public void Save()
    {
        PlayerPrefs.SetInt("progress",2);
    }
}

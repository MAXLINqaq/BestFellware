using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyrocope : MonoBehaviour
{
    //����ֻ�������
    bool gyinfo;
    public Vector3 a;
    Gyroscope go;
    void Awake()
    {
        gyinfo = SystemInfo.supportsGyroscope;
        go = Input.gyro;
        go.enabled = true;
    }
    void Update()
    {
        if (gyinfo)
        {
            a = go.attitude.eulerAngles;
            a = new Vector3(-a.x, -a.y, a.z);
            this.transform.eulerAngles = a;
        }
    }
}

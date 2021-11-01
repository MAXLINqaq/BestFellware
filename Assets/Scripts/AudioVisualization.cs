using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualization : MonoBehaviour
{
    public static float volume;
    private AudioClip micRecord;
    string device;
    /// <summary>
    /// ��β���ƶ��ٶ�   Ҫ����������ƶ��ٶ�һ��
    /// </summary>
    private int speed;
    private float x;
    void Start()
    {
        //��ʼ���ٶȵ�ֵ
        speed = 5;
        device = Microphone.devices[0];//��ȡ�豸��˷�
        micRecord = Microphone.Start(device, true, 999, 44100);//44100��Ƶ������   �̶���ʽ
    }
    void Update()
    {
        volume = GetMaxVolume();
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        //Ҫ��������Ч  ������β
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        x = gameObject.transform.position.x;
        //print(volume);
        //�����ֵ
        if (volume > 0.9f)
        {
            volume = volume * speed * Time.deltaTime;
            gameObject.transform.position = new Vector3(x, volume * 10, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(x, volume * 10, 0);
        }
    }
    //ÿһ������һ֡���յ���Ƶ�ļ�
    float GetMaxVolume()
    {
        float maxVolume = 0f;
        //������Ƶ
        float[] volumeData = new float[128];
        int offset = Microphone.GetPosition(device) - 128 + 1;
        if (offset < 0)
        {
            return 0;
        }
        micRecord.GetData(volumeData, offset);

        for (int i = 0; i < 128; i++)
        {
            float tempMax = volumeData[i];//�޸�����������ֵ
            if (maxVolume < tempMax)
            {
                maxVolume = tempMax;
            }
        }
        return maxVolume;
    }

}

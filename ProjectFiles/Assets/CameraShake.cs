using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{


    private float shakeAmount = 0.5f;
    private float decreaseFactor = 1.0f;
    private Vector3 originalPos;
    public bool startShake;
    public float shake;

    private void Awake()
    {
        originalPos = transform.localPosition;
    }
    void Update()
    {
        if (startShake)
        {
            Shake();
        }

    }
    public void ShakeOnEnable()
    {
        startShake = true;
        shake = 0.5f;
    }
    private void Shake()
    {
        transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        shake -= Time.deltaTime * decreaseFactor;
        if (shake <= 0)
        {
            startShake = false;
            transform.localPosition = originalPos;
        }

    }
}

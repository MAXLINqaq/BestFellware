using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource As;// Start is called before the first frame update
    public float PlayTime;
    private float invokeTime;
    void Start()
    {
        As = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!As.loop)
        {
            if (As.isPlaying)
            {
                invokeTime += Time.deltaTime;
                if (invokeTime > PlayTime)
                {
                    As.Stop();
                    invokeTime = 0;
                }
            }
        }
    }
}

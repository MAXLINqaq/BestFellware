using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetupController : MonoBehaviour
{
    public Slider slider;
    

    // Update is called once per frame
    void Update()
    {
        AudioSlider();
    }
    private void AudioSlider()
    {
        AudioListener.volume=slider.value;
    }
}

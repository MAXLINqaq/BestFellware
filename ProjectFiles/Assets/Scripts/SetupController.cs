using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetupController : MonoBehaviour
{
    public Slider slider;
    public GameObject panel;



    // Update is called once per frame
    void Update()
    {
        AudioSlider();
    }
    private void AudioSlider()
    {
        AudioListener.volume = slider.value;
    }
    public void ClickedShow()
    {
        panel.SetActive(true);
    }
    public void ClickedHide()
    {
        panel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

}

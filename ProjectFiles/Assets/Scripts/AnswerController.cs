using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnswerController : MonoBehaviour
{
    public Text AnswerText;
    private int i = 0;
    private bool isPrint = false;
    private int j = 0;
    private float invokeTime;
    private float currentTime=0.1f;

    [Serializable]
    public struct Sentence
    {
        public string words;
    };

    public Sentence[] sentences;
    private void Update()
    {
        if (isPrint)
        {
            invokeTime += Time.deltaTime;
            if (invokeTime > currentTime)
            {
                AnswerText.text = sentences[i].words.Substring(0, j);
                j++;
            }
            if (j == sentences[i].words.Length)
            {
                isPrint = false;
            }
            i ++;
        }
    }
    public void Answer() 
    {
        isPrint = true;
    }
}

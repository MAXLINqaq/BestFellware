using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Fungus;
using UnityEngine.Experimental.Rendering.Universal;



public class MorsecodeController : MonoBehaviour
{


    public float SetTime = 1;
    public float invokeTime;
    public AudioSource As;
    private bool isDown = false;
    public GameObject Up;

    private int i = 0;
    private float SinvokeTime;
    private string CountDown;
    private int storyCount = 0;
    private bool isExcute = false ;
    private bool isCoding = false ;
    private string BlockStr ;
    private string D = "D";

    public Text Sentence1Text;
    public Text TargetText;
    public Text MorseText;
    public Text TimeText1;
    public Text TimeText2;
    public Text TimeText3;
    public Text TimeText4;

    public string AnswerStr;
    public string MorseStr;


    [Serializable]
    public struct Sentence
    {
        public string words;
        public string target;
        public string Morse;
        public float time;
    };

    //序列化，才能显示在层次面板上


    public Sentence[] sentences;







    private void Update()
    {
        if (isDown)
        {
            invokeTime += Time.deltaTime;
            Up.transform.localScale = new Vector3(0, 0, 0);
        }
        if (isDown == false && invokeTime != 0)
        {
            SetValue();
            Up.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }

        PlayAudio();

        StoryController();
        GameplayController();
    }
    public void IsDown()
    {
        isDown = true;
    }
    public void IsUp()
    {
        isDown = false;
    }
    public void SetisCoding()
    {
        isCoding = true ;
    }
    private void SetValue()
    {
        if (invokeTime >= SetTime)
        {
            AnswerStr = AnswerStr.Insert(AnswerStr.Length , "1");
            MorseStr = MorseStr.Insert(MorseStr.Length, "-");

            invokeTime = 0;
        }
        else
        {
            AnswerStr = AnswerStr.Insert(AnswerStr.Length, "0");
            MorseStr = MorseStr.Insert(MorseStr.Length, "·");
            invokeTime = 0;
        }
    }
    private void PlayAudio()
    {
        if (isDown && !As.isPlaying)
        {
            As.Play();
        }
        if (!isDown && As.isPlaying)
        {
            As.Stop();
        }
    }
    private void GameplayController()
    {
        if (isCoding)
        {
            SinvokeTime += Time.deltaTime;
            if (SinvokeTime > sentences[i].time)
            {
                i++;
                SinvokeTime = 0;
            }
            Sentence1Text.text = sentences[i].words;
            TargetText.text = sentences[i].target;
            MorseText.text = MorseStr;

            CountDown = Convert.ToString(sentences[i].time - SinvokeTime);
            TimeText1.text = Convert.ToString(CountDown[0]);
            TimeText2.text = Convert.ToString(CountDown[1]);
            //TimeText3.text = Convert.ToString(CountDown[3]);
            //TimeText4.text = Convert.ToString(CountDown[4]);

            if (AnswerStr.Length == sentences[i].Morse.Length)
            {
                if (AnswerStr == sentences[i].Morse)
                {
                    i++;
                    SinvokeTime = 0;
                    AnswerStr = "";
                    MorseStr = "";
                    isExcute = false;
                    isCoding = false;
                }
                else
                {
                    AnswerStr = "";
                    MorseStr = "";
                }
            }
        }
        if (!isCoding)
        {
            Sentence1Text.text = "";
            TargetText.text = "";
            MorseText.text = "";
            TimeText1.text = "0";
            TimeText2.text = "0";
        }
    }
    private void StoryController()
    {
        if(!isExcute)
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            BlockStr = D.Insert(D.Length, Convert.ToString(storyCount));
            flowchart.ExecuteBlock(BlockStr);
            isExcute = true;
            storyCount++;
        }      
    }
}

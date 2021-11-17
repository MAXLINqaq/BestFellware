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
    public AudioSource Pulse;
    private bool isDown = false;
    public GameObject Up;
    public  int missCount;
    public GameObject Blood;

    private int i = 0;
    private int j = 0;
    private float SinvokeTime;
    private string CountDown;
    private int storyCount = 0;
    private bool isExcute = false ;
    private bool isCoding = false ;
    private bool isComing = false ;
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
    public Sentence[] sentences;

    [Serializable]
    public struct SentenceCome
    {
        public string words;
        public string target;
        public string Morse;
        public float time;
    };
    public Sentence[] sentencesCome;






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

        if (missCount != 2)
        {
            StoryController();
        }
        Miss();

        GameplayController();
        //ReplyController();
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
    public void SetisComing()
    {
        isComing = true;
    }
    public void SetMissCount()
    {
        missCount = 0;
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
            MorseStr = MorseStr.Insert(MorseStr.Length, "¡¤");
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
                missCount++;
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

            if (AnswerStr.Length >= sentences[i].Morse.Length)
            {
                if (AnswerStr == sentences[i].Morse)
                {
                    missCount=0;
                    i++;
                    SinvokeTime = 0;
                    AnswerStr = "";
                    MorseStr = "";
                    if (storyCount < 10)
                    {
                        isExcute = false;
                        isCoding = false;
                    }
                    else
                    {
                        isCoding = true ;
                    }
                    missCount = 0;
                }
                else
                {
                    missCount++;
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
        if (i > 15)
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            flowchart.ExecuteBlock("D11");
        }
    }
    //private void ReplyController()
    //{
    //    if (isComing)
    //    {
    //        SinvokeTime += Time.deltaTime;
    //        if (SinvokeTime > sentencesCome[j].time)
    //        {
    //            j++;
    //            SinvokeTime = 0;
    //        }
    //    }
    //}

    private void StoryController()
    {
        if (!isExcute)
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            BlockStr = D.Insert(D.Length, Convert.ToString(storyCount));
            flowchart.ExecuteBlock(BlockStr);
            isExcute = true;
            storyCount++;
        }
    }
    public void DeleteCode()
    {
        if (AnswerStr.Length != 0)
        {
            AnswerStr = AnswerStr.Substring(0, AnswerStr.Length - 1);
        }
        if (MorseStr.Length != 0)
        {
            MorseStr = MorseStr.Substring(0, MorseStr.Length - 1);
        }     
    }
    private void Miss()
    {
        if (missCount == 0 && Pulse.isPlaying)
        {
            Pulse.Stop();
            Blood.transform.localScale = new Vector3(1.9f, 0, 1f);
        }

        if (missCount == 1 && !Pulse .isPlaying)
        {
            Pulse.Play();
            Blood.transform.localScale = new Vector3(1.9f, 2f, 1f);
        }
        if (missCount == 2 && Pulse.isPlaying)
        {
            isExcute = false;
            isCoding = false;
            Pulse.Stop();
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            flowchart.ExecuteBlock("Fail");
            missCount = 0;
            if (storyCount < 2)
            {
                storyCount = 0;
            }
            else if (storyCount < 5)
            {
                storyCount = 2;
            }
            else if (storyCount < 8)
            {
                storyCount = 5;
            }
            else if (storyCount < 10)
            {
                storyCount = 8;
            }
            else
            {
                storyCount = 10;
            }
        }

    }
}

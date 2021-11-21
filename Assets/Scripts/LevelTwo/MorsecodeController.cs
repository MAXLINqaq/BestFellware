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

    public  int i;
    private float SinvokeTime;
    private string CountDown;
    private int storyCount = 0;
    private bool isExcute = false ;
    private bool isCoding = false ;

    private string BlockStr ;
    private string D = "D";


    private float colorG=1;
    private float  colorB=1;
    private int flag;

    public Text Sentence1Text;
    public Text TargetText;
    public Text MorseComeText;
    public Text MorseText;
    public Text MissionText;
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
        if (missCount != 2)
        {
            GameplayController();
        }  
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
            MorseStr = MorseStr.Insert(MorseStr.Length, "，");
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
        bool  colorFlag = true ;
        if (isCoding)
        {
            SinvokeTime += Time.deltaTime;
            if (SinvokeTime > sentences[i].time)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
                missCount++;
                SinvokeTime = 0;
            }
            if (sentences[i].time > 60)
            {
                if (sentences[i].time - SinvokeTime > 60)
                {
                    CountDown = Convert.ToString(sentences[i].time - SinvokeTime - 59);
                    TimeText1.text = Convert.ToString(CountDown[0]);
                    TimeText2.text = Convert.ToString(CountDown[1]);
                    TimeText3.text = "0 ";
                    TimeText4.text = "1";
                    if (TimeText2.text == ".")
                    {
                        TimeText2.text = TimeText1.text;
                        TimeText1.text = "0";
                    }
                }
                else
                {
                    CountDown = Convert.ToString(sentences[i].time - SinvokeTime);
                    TimeText1.text = Convert.ToString(CountDown[0]);
                    TimeText2.text = Convert.ToString(CountDown[1]);
                    TimeText3.text = "0 ";
                    TimeText4.text = "0";
                    if (TimeText2.text == ".") 
                    {
                        TimeText2.text = TimeText1.text;
                        TimeText1.text = "0";
                    }
                }
            }
            else 
            {
                CountDown = Convert.ToString(sentences[i].time - SinvokeTime);
                TimeText1.text = Convert.ToString(CountDown[0]);
                TimeText2.text = Convert.ToString(CountDown[1]);
                TimeText3.text = "0 ";
                TimeText4.text = "0";
                if (TimeText2.text == ".")
                {
                    TimeText2.text = TimeText1.text;
                    TimeText1.text = "0";
                }
            }

            Sentence1Text.text = sentences[i].words;
            TargetText.text = sentences[i].target;
            MorseText.text = MorseStr;

            if (i == 1 || i == 5 || i == 12)
            {
                if (colorFlag)
                {
                    TargetText.color = Color.blue;
                    colorFlag = false;

                }
                
                if (i == 1)
                {
                    MorseComeText.text = "，---，，，--，，-，，";
                    if (AnswerStr.Length < 4)
                    {
                        Sentence1Text.text = "";
                        TargetText.text="";
                    }
                    else if (AnswerStr.Length < 7)
                    {
                        Sentence1Text.text = sentences[i].words .Substring(0,1);
                        TargetText.text = sentences[i].target.Substring(0, 1);
                    }
                    else if (AnswerStr.Length <11)
                    {
                        Sentence1Text.text = sentences[i].words.Substring(0, 2);
                        TargetText.text = sentences[i].target.Substring(0, 2);
                    }
                    else  if (AnswerStr.Length <13)
                    {
                        Sentence1Text.text = sentences[i].words.Substring(0, 3);
                        TargetText.text = sentences[i].target.Substring(0, 3);
                    }
                    else  
                    {
                        Sentence1Text.text = sentences[i].words;
                        TargetText.text = sentences[i].target;
                    }
                }
                if (i == 5)
                {
                    MorseComeText.text = "--，，-，，，，，-，，，，";
                    MorseComeText.fontSize = 55;
                    if (AnswerStr.Length < 4)
                    {
                        Sentence1Text.text = "";
                        TargetText.text = "";
                    }
                    else if (AnswerStr.Length < 8)
                    {
                        Sentence1Text.text = sentences[i].words.Substring(0, 1);
                        TargetText.text = sentences[i].target.Substring(0, 1);
                    }
                    else if (AnswerStr.Length <12)
                    {
                        Sentence1Text.text = sentences[i].words.Substring(0, 2);
                        TargetText.text = sentences[i].target.Substring(0, 2);
                    }
                    else  if (AnswerStr.Length < 14)
                    {
                        Sentence1Text.text = sentences[i].words.Substring(0, 3);
                        TargetText.text = sentences[i].target.Substring(0, 3);
                    }
                    else 
                    {
                        Sentence1Text.text = sentences[i].words;
                        TargetText.text = sentences[i].target;
                    }
                }
                if (i == 12)
                {
                    MorseComeText.text = "-，--，--，-，-，--，，-，--";
                    MorseComeText.fontSize = 40;
                    if (AnswerStr.Length < 4)
                    {
                        Sentence1Text.text = "";
                        TargetText.text = "";
                    }
                    else if (AnswerStr.Length < 8)
                    {
                        Sentence1Text.text = sentences[i].words.Substring(0, 1);
                        TargetText.text = sentences[i].target.Substring(0, 1);
                    }
                    else if (AnswerStr.Length <12)
                    {
                        Sentence1Text.text = sentences[i].words.Substring(0, 2);
                        TargetText.text = sentences[i].target.Substring(0, 2);
                    }
                    else  if (AnswerStr.Length <14)
                    {
                        Sentence1Text.text = sentences[i].words.Substring(0, 3);
                        TargetText.text = sentences[i].target.Substring(0, 3);
                    }
                    else  if (AnswerStr.Length <16)
                    {
                        Sentence1Text.text = sentences[i].words.Substring(0, 4);
                        TargetText.text = sentences[i].target.Substring(0, 4);
                    }
                    else  
                    {
                        Sentence1Text.text = sentences[i].words;
                        TargetText.text = sentences[i].target;
                    }
                }

                MissionText.text = "俊辺佚連��";

            }
            else
            {
                TargetText.color = Color.red;
                MissionText.text = "窟僕佚連��";
            }

            if (AnswerStr.Length >= sentences[i].Morse.Length)
            {
                if (sentences[i].Morse.Length > 16)
                {
                    MorseText.fontSize = 40;
                }
                else
                {
                    MorseText.fontSize = 60;
                }
                if (AnswerStr == sentences[i].Morse)
                {
                    MorseComeText.text = "";
                    
                    missCount = 0;
                    i++;
                    SinvokeTime = 0;
                    AnswerStr = "";
                    MorseStr = "";
                    if (storyCount < 13)
                    {
                        isExcute = false;
                        isCoding = false;
                    }
                    else
                    {
                        isCoding = true;
                        isExcute = false ;
                    }
                    missCount = 0;
                    MissionText.text = "";
                }
                else
                {
                    MissionText.text = "";
                    missCount++;
                    AnswerStr = "";
                    MorseStr = "";
                }
                colorFlag = true;
            }  
        }
        if (!isCoding)
        {
            Sentence1Text.text = "";
            MissionText.text = "";
            TargetText.text = "";
            MorseText.text = "";
            TimeText1.text = "0";
            TimeText2.text = "0";
            TimeText3.text = "0";
            TimeText4.text = "0";
        }
        if (i > 17)
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            flowchart.ExecuteBlock("D16");
        }
    }
    
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
        if (missCount == 1)
        {
            Blood.GetComponent<SpriteRenderer>().color = new Vector4(1, colorG, colorG, 1);
            if (colorB >= 1 && colorG >= 1)
            {
                flag = -1;
                colorG = 0;
                colorB = 0;
            }
            if (colorB <= 0 && colorG <= 0)
            {
                flag = 1;
                colorG = 0;
                colorB = 0;
            }
            colorG = Time.deltaTime * flag + colorG;
            colorB = Time.deltaTime * flag + colorB;
        }
        if (missCount == 2 && Pulse.isPlaying)
        {
            Sentence1Text.text = "";
            TargetText.text = "";
            Blood.transform.localScale = new Vector3(1.9f, 0, 1f);
            colorG = 1f;
            colorB = 1f;
            isExcute = false;
            isCoding = false;
            Pulse.Stop();
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            flowchart.ExecuteBlock("Fail");
            
            if (storyCount < 4)
            {
                storyCount = 0;
            }
            else if (storyCount < 7)
            {
                storyCount = 4;
            }
            else if (storyCount < 10)
            {
                storyCount = 7;
            }
            else if (storyCount < 12)
            {
                storyCount = 10;
            }
            else
            {
                storyCount = 12;
            }
        }
    }
}

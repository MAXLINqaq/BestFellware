using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        Application.Quit();
    }

    public void Load()
    {
        if (!PlayerPrefs.HasKey("progress"))
        {
            SceneManager.LoadScene("LevelOne");
        }
        else
        {
            int temp;
            temp = PlayerPrefs.GetInt("progress");
            if (temp == 1 || temp == 3||temp ==5)
            {
                SceneManager.LoadScene("otherworld");
            }
            else if (temp == 2)
            {
                SceneManager.LoadScene("LevelTwo");
            }
            else
            {
                SceneManager.LoadScene("LevelThree");
            }
        }

    }
     public void DeleteKey() 
    {
        PlayerPrefs. DeleteAll();
    }
}

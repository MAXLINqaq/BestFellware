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
            SceneManager.LoadScene("otherworld");
        }

    }
}

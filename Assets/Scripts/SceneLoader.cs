using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string level;
    public void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadAllLevels()
    {
        SceneManager.LoadScene("AllLevels");
    }

    public void LoadBlockScene()
    {
        SceneManager.LoadScene("BlockScene");
    }

    public void LoadLevel()
    { 
        SceneManager.LoadScene(level);
    }
}

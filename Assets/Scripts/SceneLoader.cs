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
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("level");
    }
}

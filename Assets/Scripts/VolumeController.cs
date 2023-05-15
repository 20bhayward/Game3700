using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class VolumeController : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeText = null;
    [SerializeField] private Slider volumeSlider = null;


    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeText.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("mastervolume", AudioListener.volume);
    }

    public void button_exit()
    {

        Application.Quit();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public AudioMixer audioMixer;

    public void Mute(bool b)
    {
        if (b)
        {
            audioMixer.SetFloat("volume", 0f);
        }
        else
        {
            audioMixer.SetFloat("volume", -80f);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}

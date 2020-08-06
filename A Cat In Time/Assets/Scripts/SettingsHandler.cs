using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsHandler : MonoBehaviour
{
    public static SettingsHandler Instance;
    public bool[] wasInRoom = new bool[4];
    public bool[] didRiddle = new bool[4];


    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(this.gameObject);
    }

    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene: " + scene.buildIndex);
        switch (scene.buildIndex)
        {
            case 1:
                wasInRoom[0] = true;
                break;
            case 3:
                wasInRoom[1] = true;
                break;
            case 5:
                wasInRoom[2] = true;
                break;
            case 7:
                wasInRoom[3] = true;
                break;
        }
    }
}

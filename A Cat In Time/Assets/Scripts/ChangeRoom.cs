using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeRoom : MonoBehaviour
{
    public static ChangeRoom Instance;

    private GameObject[] buttons = new GameObject[4];
    private GameObject chooseRoomUI;

    [SerializeField]
    private bool didRiddle = false;

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    private void Start()
    {
        chooseRoomUI = GameObject.Find("ChangeRoomUI");
        buttons[0] = GameObject.Find("ToKornmarkt");
        buttons[1] = GameObject.Find("ToTanzsaal");
        buttons[2] = GameObject.Find("ToBürgerstube");
        buttons[3] = GameObject.Find("ToAbort");

        chooseRoomUI.SetActive(false);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    public void Clicked()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            prepareUI();
        }
        else if (SettingsHandler.Instance.didRiddle[0])
        {
            prepareUI();
        }   
    }

    private void prepareUI()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    if (i != 0 && SettingsHandler.Instance.wasInRoom[i])
                    {
                        buttons[i].SetActive(true);
                    }
                }
                if (SettingsHandler.Instance.didRiddle[0])
                {
                    buttons[1].SetActive(true);
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    if (i != 1 && SettingsHandler.Instance.wasInRoom[i])
                    {
                        buttons[i].SetActive(true);
                    }
                }
                if (SettingsHandler.Instance.didRiddle[1])
                {
                    buttons[2].SetActive(true);
                }
                break;
            case 5:
                for (int i = 0; i < 4; i++)
                {
                    if (i != 2 && SettingsHandler.Instance.wasInRoom[i])
                    {
                        buttons[i].SetActive(true);
                    }
                }
                if (SettingsHandler.Instance.didRiddle[2])
                {
                    buttons[3].SetActive(true);
                }
                break;
            case 7:
                for (int i = 0; i < 4; i++)
                {
                    if (i != 3&& SettingsHandler.Instance.wasInRoom[i])
                    {
                        buttons[i].SetActive(true);
                    }
                }
                break;
        }

        chooseRoomUI.SetActive(true);

    }

}

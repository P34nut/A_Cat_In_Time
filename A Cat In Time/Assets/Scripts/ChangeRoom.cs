using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeRoom : MonoBehaviour
{
    public GameObject[] buttons = new GameObject[4];
    public GameObject chooseRoomUI;

    [SerializeField]
    private bool didRiddle = false;

    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            prepareUI();
        }
        else if (didRiddle)
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
                if (didRiddle)
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
                if (didRiddle)
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
                if (didRiddle)
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

    public void setDidRiddle()
    {
        didRiddle = true;
    }

}

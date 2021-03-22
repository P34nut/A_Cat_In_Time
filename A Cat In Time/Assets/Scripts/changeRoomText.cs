using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class changeRoomText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI roomText;


    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene arg0, LoadSceneMode arg)
    {
        StartCoroutine(changeText());
    }

    IEnumerator changeText()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                roomText.gameObject.SetActive(true);
                roomText.text = "Kornmarkt heute";
                yield return new WaitForSecondsRealtime(3f);
                roomText.text = "";
                roomText.gameObject.SetActive(false);
                break;
            case 2:
                roomText.gameObject.SetActive(true);
                roomText.text = "Kornmarkt 1607";
                yield return new WaitForSecondsRealtime(3f);
                roomText.text = "";
                roomText.gameObject.SetActive(false);
                break;
            case 3:
                roomText.gameObject.SetActive(true);
                roomText.text = "Tanzsaal heute";
                yield return new WaitForSecondsRealtime(3f);
                roomText.text = "";
                roomText.gameObject.SetActive(false);
                break;
            case 4:
                roomText.gameObject.SetActive(true);
                roomText.text = "Tanzsaal 1607";
                yield return new WaitForSecondsRealtime(3f);
                roomText.text = "";
                roomText.gameObject.SetActive(false);
                break;
            case 5:
                roomText.gameObject.SetActive(true);
                roomText.text = "Bürgerstube heute";
                yield return new WaitForSecondsRealtime(3f);
                roomText.text = "";
                roomText.gameObject.SetActive(false);
                break;
            case 6:
                roomText.gameObject.SetActive(true);
                roomText.text = "Bürgerstube 1607";
                yield return new WaitForSecondsRealtime(3f);
                roomText.text = "";
                roomText.gameObject.SetActive(false);
                break;
            case 7:
                roomText.gameObject.SetActive(true);
                roomText.text = "Abort 1607";
                yield return new WaitForSecondsRealtime(3f);
                roomText.text = "";
                roomText.gameObject.SetActive(false);
                break;
        }
    }

}

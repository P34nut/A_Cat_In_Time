using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
   
    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        gameObject.SetActive(false);
    }

    public void OpenURL()
    {
        Application.OpenURL("https://www.tuebingen.de/stadtmuseum/");
        Application.Quit();
    }

}

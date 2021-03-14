using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showTokenUI : MonoBehaviour
{
    public Image[] tokenImages;
    public Sprite[] tokenSprites;
    public static showTokenUI Instance;

    private void Awake()
    {
        Instance = this;
        //gameObject.SetActive(false);
    }

    public void setTokenUI(int index)
    {
        tokenImages[index].sprite = tokenSprites[index];
        //if (!gameObject.activeInHierarchy)
        //{
        //    gameObject.SetActive(true);
        //}
        
    }
}

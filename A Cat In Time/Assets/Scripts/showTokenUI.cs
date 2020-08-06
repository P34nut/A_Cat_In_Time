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
        DontDestroyOnLoad(gameObject);
    }

    public void setTokenUI(int index)
    {
        tokenImages[index].sprite = tokenSprites[index]; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitrine : MonoBehaviour
{
    public GameObject cat;
    public GameObject[] tokens;

    private void OnMouseDown()
    {
        Debug.Log("Clicked Vitrine");
        cat.GetComponent<CatMoveTo>().BeginMovement();
    }

    private void Awake()
    {
        showTokens();
    }

    void showTokens()
    {
        for (int i = 0; i < tokens.Length; i++)
        {
            if (SettingsHandler.Instance.didRiddle[i])
            {
                tokens[i].SetActive(true);
            }
        }
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

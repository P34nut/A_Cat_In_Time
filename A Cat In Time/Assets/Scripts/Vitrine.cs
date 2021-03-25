using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitrine : MonoBehaviour
{
    public GameObject cat;
    public GameObject[] tokens;
    public GameObject text;
    public GameObject outlineObject;

    [SerializeField]
    private GameObject endScreen;

    private void OnMouseDown()
    {

        if (SettingsHandler.Instance.didAllRiddles())
        {
            endScreen.SetActive(true);
        }
        else if (SettingsHandler.Instance.didRiddle[0])
        {
            return;
        }
        else
        {
            cat.GetComponent<CatMoveTo>().BeginMovement();
            StartCoroutine(ShowText());
        }
        
    }

    private IEnumerator ShowText()
    {
        outlineObject.SetActive(true);
        text.SetActive(true);

        yield return new WaitForSeconds(4f);

        text.SetActive(false);

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
        if (SettingsHandler.Instance.didRiddle[0])
        {
            outlineObject.SetActive(true);
        }
        else
        {
            outlineObject.SetActive(false);
        }
        
        showTokens();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] cats;

    // Start is called before the first frame update
    void Start()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;

        switch (scene)
        {
            case 1:
                if (SettingsHandler.Instance.didRiddle[0])
                {
                    cats[0].transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                    cats[0].GetComponent<CatMoveTo>().BeginMovement();
                }
                break;
            case 2:
                cats[1].transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                cats[1].GetComponent<CatMoveTo>().BeginMovement();
                break;
            case 3:
                if (!SettingsHandler.Instance.didRiddle[1])
                {
                    cats[2].transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                    cats[2].GetComponent<CatMoveTo>().BeginMovement();
                }
                else if(SettingsHandler.Instance.didRiddle[1])
                {
                    cats[3].transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                    cats[3].GetComponent<CatMoveTo>().BeginMovement();
                }
                break;
            case 4:
                cats[4].transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                cats[4].GetComponent<CatMoveTo>().BeginMovement();
                break;
            case 5:
                if (!SettingsHandler.Instance.didRiddle[2])
                {
                    cats[5].transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                    cats[5].GetComponent<CatMoveTo>().BeginMovement();
                }
                else if (SettingsHandler.Instance.didRiddle[2] && !SettingsHandler.Instance.didRiddle[3])
                {
                    cats[6].transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                    cats[6].GetComponent<CatMoveTo>().BeginMovement();
                }
                if(SettingsHandler.Instance.didRiddle[2] && SettingsHandler.Instance.didRiddle[3])
                {
                    cats[7].transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                    cats[7].GetComponent<CatMoveTo>().BeginMovement();
                }
                break;
            case 6:
                cats[8].transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                cats[8].GetComponent<CatMoveTo>().BeginMovement();
                break;
        }
    }
    
}

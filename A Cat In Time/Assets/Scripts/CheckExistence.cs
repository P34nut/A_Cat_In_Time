using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class CheckExistence : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasPrefab;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject SpawnLocation;
    [SerializeField]
    private GameObject Player;

    private GameObject infoText;
    private bool startLookAt = false;

    private void Awake()
    {

        if (!GameObject.Find("CanvasPrefab"))
        {
          GameObject prefab =  Instantiate<GameObject>(canvasPrefab);
            prefab.name = "CanvasPrefab";
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            
            if (SettingsHandler.Instance.onSpawnLocation)
            {
                Player.transform.position = SpawnLocation.transform.position;
                Player.transform.rotation = SpawnLocation.transform.rotation;
                Player.GetComponent<NavMeshAgent>().Warp(SpawnLocation.transform.position);
            }
        }
        else
        {
            Player = Instantiate(playerPrefab);
            Player.transform.position = SpawnLocation.transform.position;
            Player.transform.rotation = SpawnLocation.transform.rotation;
            Player.GetComponent<NavMeshAgent>().Warp(SpawnLocation.transform.position);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && !SettingsHandler.Instance.didRiddle[0])
        {
            infoText = GameObject.Find("whiteboard_Steuerung");
            StartCoroutine(WaitForLookAt());
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1 && SettingsHandler.Instance.didRiddle[0])
        {
            GameObject.Find("cat_prefab_toDoor").GetComponent<CatMoveTo>().BeginMovement();
        }
    }

    private void Update()
    {
        if (startLookAt)
        {
            Camera.main.transform.LookAt(infoText.transform);
        }
    }

    IEnumerator WaitForLookAt()
    {
        startLookAt = true;
        yield return new WaitForSecondsRealtime(10f);
        startLookAt = false;
    }


}

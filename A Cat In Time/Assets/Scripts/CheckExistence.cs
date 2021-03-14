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


    private void Awake()
    {

        if (!GameObject.Find("CanvasPrefab"))
        {
          GameObject prefab =  Instantiate<GameObject>(canvasPrefab);
            prefab.name = "CanvasPrefab";
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Debug.Log("FIND");
            Player = GameObject.FindGameObjectWithTag("Player");
            
            if (SettingsHandler.Instance.onSpawnLocation)
            {
                Debug.Log("TRUE");
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
    }
}

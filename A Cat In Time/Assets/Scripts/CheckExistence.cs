using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckExistence : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasPrefab;

    private void Awake()
    {
        if (!GameObject.Find("CanvasPrefab"))
        {
          GameObject prefab =  Instantiate<GameObject>(canvasPrefab);
            prefab.name = "CanvasPrefab";
        }
    }
}

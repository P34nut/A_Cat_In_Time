using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateTravel : MonoBehaviour
{
    [SerializeField]
    bool isAbort;

    private void OnMouseDown()
    {

        Debug.Log("Initiate TimeTravel");
        TimeTravel.Instance.isAbort = isAbort;
        TimeTravel.Instance.DoIt();
    }
}

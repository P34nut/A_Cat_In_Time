using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateTravel : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Initiate TimeTravel");
        TimeTravel.Instance.DoIt();
    }
}

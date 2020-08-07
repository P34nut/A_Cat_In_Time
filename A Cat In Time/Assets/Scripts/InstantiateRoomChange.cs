using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRoomChange : MonoBehaviour
{
    private void OnMouseDown()
    {
        ChangeRoom.Instance.Clicked();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateOutline : MonoBehaviour
{
    [SerializeField]
    private GameObject outlineObject;
    // Start is called before the first frame update
    void Start()
    {
        if (SettingsHandler.Instance.didRiddle[2])
        {
            outlineObject.SetActive(true);
        }
        else
        {
            outlineObject.SetActive(false);
        }
    }
}

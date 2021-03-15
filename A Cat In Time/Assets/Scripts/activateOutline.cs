using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateOutline : MonoBehaviour
{
    [SerializeField]
    private GameObject outlineObject;

    [SerializeField]
    private GameObject[] travelScripts;
    // Start is called before the first frame update
    void Start()
    {
        if (SettingsHandler.Instance.didRiddle[2])
        {
            for (int i = 0; i < travelScripts.Length; i++)
            {
                travelScripts[i].AddComponent<InitiateTravel>();
                travelScripts[i].GetComponent<InitiateTravel>().isAbort = true;
            }
            outlineObject.SetActive(true);
            
        }
        else
        {
            outlineObject.SetActive(false);   
        }
    }
}

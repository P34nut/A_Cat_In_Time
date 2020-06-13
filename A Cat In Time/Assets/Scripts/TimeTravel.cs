using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    private bool travelComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StartTravel()
    {
        Debug.Log("Time Travel begins");
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        sphere.transform.position = new Vector3(0f, 2f, 0f);
        travelComplete = true;

    }

    private void OnMouseDown()
    {
        StartTravel();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    private bool travelComplete = true;     //damit man nicht spammen kann
    private Vector3 newPos;

    private void Start()
    {
        newPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }


    private void Update()
    {
        if (!travelComplete)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * 1);
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine( StartTravel());
    }

    //This is where the magic happens
    private IEnumerator StartTravel()
    {
        if (travelComplete)
        {
            travelComplete = false;
            Debug.Log("Time Travel begins");
            yield return new WaitWhile(() => transform.position != newPos);
            travelComplete = true;
        }
       
    }

    

}

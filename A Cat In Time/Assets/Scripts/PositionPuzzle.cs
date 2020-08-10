using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPuzzle : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    private Transform playerTransform;
    private Transform mainCam;


    public static bool AlmostEqual(Vector3 v1, Vector3 v2, float precision)
    {
        bool equal = true;

        if (Mathf.Abs(v1.x - v2.x) > precision )
        {
            equal = false;
        }

        if (Mathf.Abs(v1.y - v2.y) > precision )
        {
            equal = false;
        }

        if (Mathf.Abs(v1.z - v2.z) > precision )
        {
            equal = false;
        }
        return equal;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        mainCam = Camera.main.transform;

        //mainCam.rotation = targetTransform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if ((targetTransform.position-playerTransform.position).sqrMagnitude < 1f && AlmostEqual(targetTransform.rotation.eulerAngles, mainCam.rotation.eulerAngles, 25f))
        {
            Debug.Log("Is close");
        }
    }
}

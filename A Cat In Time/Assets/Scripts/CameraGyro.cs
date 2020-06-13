using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    public GameObject camParent;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = camParent.transform;
        Input.gyro.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Rotieren auf zwei unterschiedlichen Objekten macht es smoother
        camParent.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y / 2, 0);
        transform.Rotate(-Input.gyro.rotationRateUnbiased.x / 2, 0, 0);
    }
}

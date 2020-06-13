using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    private GameObject camParent;
    private bool gyroEnabled;
    private Gyroscope gyroscope;
    private Quaternion rotation;
    private Quaternion adjustRotation;

    // Start is called before the first frame update
    void Start()
    {
        camParent = new GameObject("CameraParent");
        camParent.transform.position = this.transform.position;
        this.transform.parent = camParent.transform;
        Input.gyro.enabled = true;
        //camParent.transform.rotation = Quaternion.Euler(90f, -90f, 0f);
        //gyroEnabled = EnableGyro();
        //adjustRotation = Quaternion.Euler(90f, 0f, 0f) * Quaternion.Inverse(gyroscope.attitude);
    }

    // Update is called once per frame
    void Update()
    {

        camParent.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y/4, 0);
        this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x/4, 0, 0);
        //if (gyroEnabled)
        //{
         //   transform.localRotation = adjustRotation * gyroscope.attitude * rotation;
        //}
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            camParent.transform.rotation = Quaternion.Euler(90f, -90f, 0f);
            rotation = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }
}

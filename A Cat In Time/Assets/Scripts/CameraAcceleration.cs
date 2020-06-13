using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAcceleration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(-Input.acceleration.x, -Input.acceleration.y, -Input.acceleration.z);

        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        dir *= Time.deltaTime;
        transform.Translate(dir*10f);
    }
}

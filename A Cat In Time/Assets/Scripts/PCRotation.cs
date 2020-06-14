using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCRotation : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 75f;
    }

    // Update is called once per frame
    void Update()
    {

           Vector3 v3 = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0.0f);
            transform.Rotate(v3 * speed * Time.deltaTime);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCRotation : MonoBehaviour {
    public float speed;

    // Start is called before the first frame update
    void Start() {
        speed = 75f;
    }

    // Update is called once per frame
    void Update() {

        Vector3 pan = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        Vector3 tilt = new Vector3(Input.GetAxis("Vertical"), 0, 0);
        transform.Rotate(pan * speed * Time.deltaTime, Space.World);
        transform.Rotate(tilt * speed * Time.deltaTime, Space.Self);
    }
}

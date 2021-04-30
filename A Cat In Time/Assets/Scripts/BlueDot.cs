using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDot : MonoBehaviour {
    public float sec = 14f;
    public GameObject[] dots = new GameObject[4];

    void Start() {
        if (gameObject.activeInHierarchy)

            StartCoroutine(showAfterTime());
    }

    IEnumerator showAfterTime() {

        yield return new WaitForSeconds(sec);

        foreach (GameObject dot in dots)
        {
            dot.SetActive(true);
        }
    }
}

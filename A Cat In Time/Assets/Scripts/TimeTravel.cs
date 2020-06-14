using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeTravel : MonoBehaviour {
    private bool travelComplete = true;     //damit man nicht spammen kann
    private Vector3 newPos;
    private Camera mainCam;

    [SerializeField]
    private Image passout;


    private bool initiatedTravel = false;
    private Color passoutColor;

    [SerializeField]
    private float blinkduration = 2f;

    [SerializeField]
    private Gradient blinkGradient;

    private float blinkGradientPosition;

    private void Start() {
        mainCam = Camera.main;
        passoutColor = new Color(0, 0, 0, 1);
    }


    private void Update() {

        if (!initiatedTravel) {
            blinkGradientPosition += 1/blinkduration * Time.deltaTime;
            passoutColor.a = 1f - blinkGradient.Evaluate(blinkGradientPosition).r;
        }
        
        if (initiatedTravel) {
            passoutColor.a += 1.4f * Time.deltaTime;
            mainCam.fieldOfView += 90 * Time.deltaTime;
        }
        passout.color = passoutColor;
    }

    private void OnMouseDown() {
        initiatedTravel = true;
        StartCoroutine(StartTravel());
    }

    //thIs Is wHErE tHe mAGiC HapENs
    private IEnumerator StartTravel() {
        yield return new WaitForSeconds(1f);
        //EKELHAFT. HARDCODED. DIRTY. PAH!
        if (SceneManager.GetActiveScene().name == "Testlauf_2020") {
            SceneManager.LoadScene("Testlauf_1600");
        } else {
            SceneManager.LoadScene("Testlauf_2020");
        }
    }



}

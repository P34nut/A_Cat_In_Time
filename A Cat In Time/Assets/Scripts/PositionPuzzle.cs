using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPuzzle : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    private Transform playerTransform;
    private Transform mainCam;
    [SerializeField]
    private Transform targetLookAt;
    [SerializeField]
    private bool startRiddle;
    private SkinnedMeshRenderer skinned;
    [SerializeField]
    int id;
    bool startBlend = false;
    float blendValue = 100f;
    [SerializeField]
    float blendSpeed;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        mainCam = Camera.main.transform;
        skinned = GetComponent<SkinnedMeshRenderer>();

        //mainCam.rotation = targetTransform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (startRiddle)
        {
            /*if ((targetTransform.position - playerTransform.position).sqrMagnitude < 0.5f)
            {
                Debug.Log("Postion close");
            }*/

            if ((targetTransform.position - playerTransform.position).sqrMagnitude < 0.75f && AlmostEqual(targetTransform.rotation.eulerAngles, mainCam.rotation.eulerAngles, 5f))
            {
                moveFracture();
                
                
            }
        }

        if (startBlend && blendValue >= 0f)
        {
            mainCam.LookAt(targetLookAt);
            skinned.SetBlendShapeWeight(0, blendValue);
            blendValue -= blendSpeed;
        }

    }

    public static bool AlmostEqual(Vector3 v1, Vector3 v2, float precision)
    {
        bool equal = true;

        if (Mathf.Abs(v1.x - v2.x) > precision)
        {
            equal = false;
        }

        if (Mathf.Abs(v1.y - v2.y) > precision)
        {
            equal = false;
        }

        if (Mathf.Abs(v1.z - v2.z) > precision)
        {
            equal = false;
        }
        return equal;
    }

    public void StartGame()
    {
        startRiddle = true;
    }

    void moveFracture()
    {
        //skinned.SetBlendShapeWeight(0, 0);
        startBlend = true;
        PositionPuzzleHadler.Instance.isCorrect[id] = true;
        startRiddle = false;
    }


}

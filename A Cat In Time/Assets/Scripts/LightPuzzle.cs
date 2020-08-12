using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour
{
    [SerializeField]
    private Material emitMat;

    [SerializeField]
    private Material unemitMat; //falls alle Objekte ein anderes Material haben --> Array

    private Light pointLight;

    [SerializeField]
    private bool[] foundObj;

    [SerializeField]
    private int[] correctOrder;

    [SerializeField]
    private GameObject[] objects;

    private int counter = 0;
    [SerializeField]
    private int amountOfObjects;

    // Start is called before the first frame update
    void Start()
    {
        pointLight = GetComponent<Light>();
        foundObj = new bool[amountOfObjects];
        //correctOrder = new int[4];                //evtl zufällig machen?
        objects = new GameObject[amountOfObjects];

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 p1 = transform.position;
        RaycastHit hit;

        if (Physics.Raycast(p1,transform.forward,out hit, pointLight.range,LayerMask.GetMask("Riddle")))
        {
            Debug.Log("HIT");
            Debug.DrawRay(p1, transform.forward * pointLight.range, Color.green);
            EmitObject(hit.transform.gameObject);
        }
        else
        {
            Debug.DrawRay(p1, transform.forward * pointLight.range, Color.red);
        }

    }

    void EmitObject(GameObject obj)
    {
        unemitMat = obj.GetComponent<MeshRenderer>().material;
        obj.GetComponent<MeshRenderer>().material = emitMat;
        obj.layer = 0;
        StartCoroutine( CheckForWin(obj));
    }

    void DeEmitObjects(GameObject obj)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                objects[i].GetComponent<MeshRenderer>().material = unemitMat;
                objects[i].layer = 10;
            }
            
        }

        objects = new GameObject[amountOfObjects];

    }

    IEnumerator CheckForWin(GameObject obj)
    {
        int id = obj.GetComponent<LightPuzzleID>().ID;

        objects[id] = obj;

        if (id == correctOrder[counter])
        {
            
            counter++;
            foundObj[id] = true;

            for (int i = 0; i < foundObj.Length; i++)
            {
                if (!foundObj[i])
                {
                   yield break;
                }
            }

            WonGame();
        }
        else
        {
            yield return new WaitForSeconds(2f);
            DeEmitObjects(obj);
            counter = 0;
            foundObj = new bool[amountOfObjects];
        }


    }

    void WonGame()
    {
        SettingsHandler.Instance.didRiddle[3] = true;
        showTokenUI.Instance.setTokenUI(3);
        Invoke(nameof(To2020), 3f);
    }

    void To2020()
    {
        TimeTravel.Instance.DoIt();
    }

}

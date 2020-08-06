using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MoveTo : MonoBehaviour
{
    private NavMeshAgent agent;
    Transform target;
    LayerMask mask;
    LayerMask dontMoveMask;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;               //Ob Kamera rotiert und zu getouchtem Punkt schaut oder nicht (erstmal aus, kann aber auch an wenn gewünscht)
        mask = LayerMask.GetMask("Ground");
        dontMoveMask = LayerMask.GetMask("DontMove");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Wird ein UI geklickt? Wenn ja dann don't move
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("XXXX");
                return;
            }
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            RaycastHit hit2;

            if (Physics.Raycast(ray, out hit2, 100, dontMoveMask))
            {
                Debug.Log("Hit dont move");
            }

            //check ob der Boden getroffen wird und kein anderes Objekt dazwischen ist
            if(Physics.Raycast(ray, out hit,100,mask) && !Physics.Raycast(ray, out hit2, 100, dontMoveMask))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}

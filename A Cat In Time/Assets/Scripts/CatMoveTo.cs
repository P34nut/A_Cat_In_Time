using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMoveTo : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    [SerializeField]
    bool interactedVitrine;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target!=null && interactedVitrine)
        {
            agent.SetDestination(target.position);
            agent.updateRotation = true;
        }
    }


}

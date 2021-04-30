using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CatMoveTo : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public GameObject cat;

    [SerializeField]
    bool beginMovement;

    bool catArrived = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void BeginMovement()
    {
        beginMovement = true;

        if (target != null && beginMovement)
        {
            cat.SetActive(true);
            agent.SetDestination(target.position);
            agent.updateRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance == 0 && beginMovement && !catArrived)
        {
            //Debug.Log("Arrived");
            cat.SetActive(false);
            catArrived = true;
        }
    }


}

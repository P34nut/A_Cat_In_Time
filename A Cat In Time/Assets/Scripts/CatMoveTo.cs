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
    bool interactedVitrine;

    bool catArrived = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //cat.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            BeginMovement();
        }
    }

    public void BeginMovement()
    {
        interactedVitrine = true;

        if (target != null && interactedVitrine)
        {
            cat.SetActive(true);
            agent.SetDestination(target.position);
            agent.updateRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance == 0 && interactedVitrine && !catArrived)
        {
            //Debug.Log("Arrived");
            cat.SetActive(false);
            catArrived = true;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMoveTo : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public GameObject cat;

    [SerializeField]
    bool interactedVitrine;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (target!=null && interactedVitrine)
        {
            cat.SetActive(true);
            agent.SetDestination(target.position);
            agent.updateRotation = true;
        }
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    

    public GameObject Player;

    private NavMeshAgent navMeshAgent;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The navMeshAgent has no Component");

        }
        else
        {
            SetDestination();
        }


    }

    private void SetDestination()
    {
        if (destination != null)
        {
            destination = Player.transform.position;

            navMeshAgent.SetDestination(destination);
            navMeshAgent.speed = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

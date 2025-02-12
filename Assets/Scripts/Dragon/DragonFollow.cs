using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonFollow : MonoBehaviour
{
    [Header("Tracking")]
    private GameObject destination;   
    private NavMeshAgent agent;

    public Transform[] waypoints;
   
    // Start is called before the first frame update
    void Start()
    {
        // sets destination
        destination = GameObject.FindGameObjectWithTag("Player");
        // Connects to Nav Mesh Agent
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        // Updates the destionation to players current location
        agent.SetDestination(destination.transform.position);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class DragonFollow : MonoBehaviour
{
    [Header("Tracking")]
    private GameObject destination;   
    private NavMeshAgent agent;

    private float speed;

    [Header("BackUp")]
    private bool isGazingUpon;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        // sets destination
        destination = GameObject.FindGameObjectWithTag("Player");
        // Connects to Nav Mesh Agent
        agent = GetComponent<NavMeshAgent>();
        speed = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        //If in raycast veiw, move backwards
        if (isGazingUpon == true)
        {
            //Reverses destination direction
            Vector3 oppositeDirection = transform.position - destination.transform.position;
            agent.SetDestination(oppositeDirection);
            //Once it has been seen, destroy dragon after _ sec.
            Destroy(this.gameObject, 3f);
        }
        else
        {  
            // Updates the destionation to players current location
            agent.SetDestination(destination.transform.position);

            //Code to get speed to work
            Vector3 direction = destination.transform.position - transform.position;
            direction.Normalize();
            Vector3 movement = direction * speed * Time.deltaTime;
            transform.position += movement;
        }
    }

    public void GazingUpon()
    {
        isGazingUpon = true;
    }

    public void NotGazingUpon()
    {
        isGazingUpon = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DragonFollow : MonoBehaviour
{
    [Header("Tracking")]
    private GameObject destination;   
    private NavMeshAgent agent;

    [Header("BackUp")]
    private bool isGazingUpon;

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
        //look at script
        Vector3 scale = transform.localScale;

        if (destination.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else 
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        transform.LookAt(destination.transform);


        //If in raycast veiw, move backwards
        if (isGazingUpon == true)
        {
            //Reverses destination direction
            Vector3 oppositeDirection = transform.position - destination.transform.position;
            
            agent.SetDestination(oppositeDirection);
            Destroy(this.gameObject, 3f);
        }
        else
        {
            // Updates the destionation to players current location
            agent.SetDestination(destination.transform.position);
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
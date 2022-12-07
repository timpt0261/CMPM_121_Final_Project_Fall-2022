using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chococat : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public bool tagged = true;
    // public LayerMask whatIsPlayer, whatIsGround;
    // public Vector3 walkPoint;
    // bool walkPointSet;
    // public float walkPointRange, sightRange;
    // public bool playerInSightRange;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!tagged) ChasePlayer();
        Debug.Log(Vector3.Distance(agent.transform.position, player.transform.position));
        if (Vector3.Distance(agent.transform.position, player.transform.position) < 10)
        {
            tagged = false;
        }
        // playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        // if (!playerInSightRange)
        // {
        //     Patroling();
        // } else 
        // {
        //     ChasePlayer();
        // }
    }

    // private void Patroling()
    // {
    //     if (!walkPointSet) 
    //     {
    //         SearchWalkPoint();
    //     }
    //     if (walkPointSet) {
    //         agent.SetDestination(walkPoint);
    //     }

    //     Vector3 distanceToWalkPoint = transform.position - walkPoint;
    //     if(distanceToWalkPoint.magnitude < 1f)
    //     {
    //         walkPointSet = false;
    //     }
    // }
    // private void SearchWalkPoint()
    // {
    //     float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //     float randomX = Random.Range(-walkPointRange, walkPointRange);

    //     walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    //     if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //     {
    //         walkPointSet = true;
    //     }
    // }

    private void ChasePlayer()
    {
          agent.destination = player.position;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Hello Kitty")
        {
            Debug.Log ("tag!!!!!!");
            //tagged = true;
        }
    }
}

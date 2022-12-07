using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Chococat : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    private GameObject cupcake;
    public float stunTime = 3;
    public bool tagged = true;
    public bool stunned = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        cupcake = GameObject.Find("Cupcake");        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!tagged && !stunned) { agent.destination = player.position; }

        if (stunned) { agent.destination = agent.transform.position; }

        if (Vector3.Distance(agent.transform.position, player.transform.position) < 15)
        {
            tagged = false;
        }
    }
    private void ChasePlayer()
    {
          agent.destination = player.position;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cupcake(Clone)") {
            Destroy(col.gameObject, 0);
            cupcake.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            stunned = true;
            Invoke("EndStun", stunTime);
        }
        if (col.gameObject.name == "Hello Kitty")
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    private void EndStun() {
        cupcake.transform.localScale = new Vector3(0, 0, 0);
        stunned = false;
    }
}

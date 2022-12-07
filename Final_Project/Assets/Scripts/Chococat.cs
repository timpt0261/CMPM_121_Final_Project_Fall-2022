using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Chococat : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public bool tagged = true;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!tagged) ChasePlayer();
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
        if (col.gameObject.name == "Hello Kitty")
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}

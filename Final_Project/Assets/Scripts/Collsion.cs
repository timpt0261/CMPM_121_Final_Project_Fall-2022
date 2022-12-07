using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collsion : MonoBehaviour
{
    public GameObject enemy;

    private float time_remaining;
    private bool tagged = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy.tag))
        {
            time_remaining = 1.0f;
            print("Time at start: " + time_remaining);
        }  
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy.tag))
        {
            time_remaining -= Time.deltaTime;
            print("Time Remaining: " + time_remaining);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy.tag)) 
        {
            if (time_remaining <= 0)
            {
                print("Your It");
                tagged = !tagged;
            }
        }

    }

}

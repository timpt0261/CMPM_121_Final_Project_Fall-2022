using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collsion : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(enemy.tag))
        {
            print(enemy.name + " is it");
        }
    }
    

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy.tag))
        {
            print(enemy.name + " is it");
        }
    }
    */

}

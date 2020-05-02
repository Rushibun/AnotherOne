using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public Transform Spawnpoint;
    public void OnCollisionEnter(Collision collision)
    {

    }
    public void OnCollisionExit(Collision collision)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CapsulePlayer"))
        {
            Debug.Log("Player Hit Me!");

            other.gameObject.transform.position = Spawnpoint.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }


}

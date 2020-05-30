using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float obstacleDamage = 0.3f;
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerData data = other.gameObject.GetComponent<PlayerData>();
            data.HitObstacle(obstacleDamage);
        }
    }
}

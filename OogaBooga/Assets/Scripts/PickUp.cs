using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    bool pickedUp = false;
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp") && !pickedUp)
        {
            PlayerData data = other.gameObject.GetComponent<PlayerData>();
            data.ChangeScore();
            pickedUp = true;
        }
    }
}

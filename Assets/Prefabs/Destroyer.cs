using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Destroy(gameObject);
            //gameObject.SetActive(false);
            target.SetActive(false);
        }      
    }
}

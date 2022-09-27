using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyerStationary : MonoBehaviour
{
    // Variables;
    public GameObject target;
    public GameObject targetSprite;
    public GameObject facingDirection;
    public GameObject detectionZone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target.SetActive(false);
            targetSprite.SetActive(false);
            facingDirection.SetActive(false);
            detectionZone.SetActive(false);
        }
    }
}

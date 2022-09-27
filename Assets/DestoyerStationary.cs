using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyerStationary : MonoBehaviour
{
    // Variables;
    public GameObject targetSprite;
    public GameObject facingDirection;
    public GameObject detectionZone;

    private void OnCollisionEnter2D(Collision2D collision)
    {    
        gameObject.SetActive(false);
        targetSprite.SetActive(false);
        facingDirection.SetActive(false);
        detectionZone.SetActive(false); 
    }
}

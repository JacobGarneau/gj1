using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTargetStationary : MonoBehaviour
{
    // Access Bar progress
    public GameObject target;
    public GameObject targetSprite;
    public GameObject facingDirection;
    public GameObject detectionZone;
    public BarBehaviour bS;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Reset Target
        if (bS.isReset && !target.activeSelf)
        {
            target.SetActive(true);
            targetSprite.SetActive(true);
            facingDirection.SetActive(true);
            detectionZone.SetActive(true);
        }
    }
}

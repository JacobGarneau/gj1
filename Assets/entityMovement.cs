using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityMovement : MonoBehaviour
{
    private Transform targetTransform;
    private float targetSpeed = 0.002f;
    private string targetDirection = "up";
    private GameObject detectionZoneUp;
    private GameObject detectionZoneDown;

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = this.GetComponent<Transform>();
        detectionZoneUp = this.gameObject.transform.GetChild(0).gameObject;
        detectionZoneDown = this.gameObject.transform.GetChild(1).gameObject;
        detectionZoneDown.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Move target according to current direction
        if (targetDirection == "up")
        {
            targetTransform.localPosition += new Vector3(0, targetSpeed, 0);
        }
        if (targetDirection == "down")
        {
            targetTransform.localPosition += new Vector3(0, -targetSpeed, 0);
        }

        // Change direction when hitting end of movmement path
        if (targetTransform.localPosition.y >= 1.5)
        {
            targetDirection = "down";
            detectionZoneDown.SetActive(true);
            detectionZoneUp.SetActive(false);
        }
        if (targetTransform.localPosition.y <= -2.5)
        {
            targetDirection = "up";
            detectionZoneDown.SetActive(false);
            detectionZoneUp.SetActive(true);
        }
    }
}

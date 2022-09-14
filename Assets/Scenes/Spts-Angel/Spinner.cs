using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private float rotZ;
    public float RotationSpeed;
    public bool ClockwiseRotation;
    public bool isThrown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isThrown);
        if (!isThrown)
        {

            // Clockwise Rotation
            if (ClockwiseRotation)
            {
                rotZ += Time.deltaTime * RotationSpeed;
            }
            else
            {
                rotZ += -Time.deltaTime * RotationSpeed;
            }

            // AntiClockwise Rotation

            // Rotate 
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
        else
        {
            rotZ = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

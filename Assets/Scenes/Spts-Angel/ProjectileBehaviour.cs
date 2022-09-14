using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    Rigidbody2D m_Rigidbody;
    float m_Speed;
    public bool isThrown;

    private float rotZ;
    public float RotationSpeed;
    public bool ClockwiseRotation;

    void Start()
    {
        isThrown = false;

        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Set the speed of the GameObject
        m_Speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {


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


        if (Input.GetKey(KeyCode.Space))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.up * m_Speed;

            // Stop Rotation
            isThrown = true;
           
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        // Stop Rotation
        //isThrown = true;
        rotZ = 0;
    }
}

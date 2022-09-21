using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    // Variables
    // Movement
    Rigidbody2D m_Rigidbody;
    public bool isThrown;
    public bool isMoving;
    public bool isSpeeding;

    // Rotation
    float rotZ;
    public float RotationSpeed = 100f;

    // Accel. & Decel.
    public float maxSpeed = 6f;
    public float timeZeroToMax = 2.5f;
    public float timeMaxToZero = 3f;
    float accelRatePerSec;
    float decelRatePerSec;
    float forwardVelocity;

    // Collision
    public bool isCollided;
    public float collisionResult;
    public float TimeLeft = 1f;
    public bool TimerOn = false;

    void Start()
    {
        // Fetch Rigidbody
        m_Rigidbody = GetComponent<Rigidbody2D>();

        // Calculate Acceleration
        accelRatePerSec = maxSpeed / timeZeroToMax;

        // Calculate Deceleration
        decelRatePerSec = -maxSpeed / timeMaxToZero;

        // Set Initial Velocity
        forwardVelocity = 0f;

        // Set Initial Status
        isThrown = false;

        // Set Initial Collision Result
        isCollided = false;
        collisionResult = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        // ROTATION MECHANIC
        // Switch Rotation ON/OFF
        // Check Velocity
        if (forwardVelocity <= 0)
        {
            isThrown = false;
        }
        else
        {
            isThrown = true;
        }
        // Rotation
        // Check Status
        if (!isThrown)
        {
            // Rotate 
            rotZ += Time.deltaTime * RotationSpeed;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }


        // LAUNCHING MECHANIC
        // Check Status
        if (forwardVelocity <= 0)
        {
            // Register Input
            if (Input.GetKey(KeyCode.Space))
            {
                // Launch
                isMoving = true;
                isSpeeding = true;
            }
        }
        // Move
        if (isMoving)
        {
            // Move Forward
            m_Rigidbody.velocity = transform.up * forwardVelocity;

            // Check Status
            // Accelerating
            if (isSpeeding)
            {
                // Start Accelerating
                forwardVelocity += accelRatePerSec * Time.deltaTime;
                forwardVelocity = Mathf.Min(forwardVelocity, maxSpeed);
            }
            // Decelerating
            else
            {
                // Start Decelerating
                forwardVelocity += decelRatePerSec * Time.deltaTime;
                forwardVelocity = Mathf.Max(forwardVelocity, 0);
            }

            // Start Deceleratin & Reset Sprint
            if (forwardVelocity >= maxSpeed)
            {
                // Stop Speeding
                isSpeeding = false;
            }
        }


        // COLLISION TIMER
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else if(TimeLeft <= 0)
            {
                isCollided = false;
                TimerOn = false;
                TimeLeft = 1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TimerOn = true;

        // Set Collision Reaction
        if (collision.gameObject.tag == "BigBoss")
        {
            // Recognize Collision
            isCollided = true;
            collisionResult = 0.1f;
        }
        else if (collision.gameObject.tag == "MediumTarget")
        {
            // Recognize Collision
            isCollided = true;
            collisionResult = 0.05f;
        }
        else if (collision.gameObject.tag == "Attacker")
        {
            // Recognize Collision
            isCollided = true;
            collisionResult = -0.2f;
        }
    }
}

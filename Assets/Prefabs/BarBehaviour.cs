using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{
    // Variables 
    float currentHealth;
    public float fillValue = 1f;
    public GameObject player;
    float declineSpeed;
    public Image fillImage;
    private Slider slider;
    public bool isReset = false;
    public float TimeLeft = 3f;
    public bool TimerOn = false;

    // Access Character Collisions
    public CharacterBehaviour bS;


    private void Awake()
    {
        // Fetch Slider
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        // Set Thirst(Damage) Speed & Bar Color
        // Check Bar Status
        if (slider.value >= 3 * slider.maxValue / 4)
        {
            // Slow Damage
            declineSpeed = 0.00001f;
            // Bar Color
            fillImage.color = new Color(210f / 255f, 52f / 255f, 32f / 255f);
        }
        else if (slider.value <= 3 * slider.maxValue / 4 && slider.value >= slider.maxValue / 4)
        {
            // Medium Damage
            declineSpeed = 0.00004f;
            // Bar Color
            fillImage.color = new Color(138f / 255f, 30f / 255f, 56f / 255f);
        }
        else if (slider.value <= slider.maxValue / 4)
        {
            // Quick Damage
            declineSpeed = 0.0002f;
            // Bar Color
            fillImage.color = new Color(65f / 255f, 27f / 255f, 80f / 255f);
        }

        // Adjust Min Value
        // Check if Bar is empty
        if (slider.value <= slider.minValue)
        {
            // Disable Bar Fill
            fillImage.enabled = false;
            // Reset Player's position
            player.transform.position = new Vector3(0.51f, -5.94f, 0f);
            // Reset Bar fill
            fillValue = 1f;
            fillImage.enabled = true;
            slider.value = fillValue;
            // Reset Targets
            isReset = true;
        }

        // Reset TIMER
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else if (TimeLeft <= 0)
            {
                isReset = true;
                TimerOn = false;
                TimeLeft = 3f;
            }
        }


        // Apply Collision Repercussions
        // Check Character Collision
        if (bS.isCollided)
        {
            // React to Collision
            fillValue += bS.collisionResult;
            bS.isCollided = false;
            // Assign Value to Slider
            slider.value = fillValue;
        }
        else
        {
            // Update Bar Value
            // Continuos Thirst Decline
            fillValue -= declineSpeed;
            // Assign Value to Slider
            slider.value = fillValue;
        }
    }
}

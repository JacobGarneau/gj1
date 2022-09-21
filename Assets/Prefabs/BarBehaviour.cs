using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{
    // Variables 
    float currentHealth;
    public float fillValue = 1f;
    float declineSpeed;
    public Image fillImage;
    private Slider slider;

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
            declineSpeed = 0.00005f;
            // Bar Color
            fillImage.color = new Color(210f / 255f, 52f / 255f, 32f / 255f);
        }
        else if (slider.value <= 3 * slider.maxValue / 4 && slider.value >= slider.maxValue / 4)
        {
            // Medium Damage
            declineSpeed = 0.00001f;
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


        // Update Bar Value
        // Continuos Thirst Decline
        fillValue -= declineSpeed;
        // Assign Value to Slider
        slider.value = fillValue;

        // Adjust Min Value
        if (slider.value <= slider.minValue)
        {
            // Disable Bar Fill
            fillImage.enabled = false;
        }


        // Apply Collision Repercussions
        // Check Character Collision
        if (bS.isCollided)
        {
            // React to Collision
            fillValue = slider.value + bS.collisionResult;
            Debug.Log(slider.value);
        }
        else
        {
            // Continuos Thirst Decline
            fillValue -= declineSpeed;
            // Assign Value to Slider
            slider.value = fillValue;
        }
    }
}

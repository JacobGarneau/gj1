using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// source code: https://youtu.be/UCAo-uyb94c

public class NeedBar : MonoBehaviour
{
    public Slider slider;
    float emptySpeed;
    public Image fillImage;
    private float targetProgress = 1;
    private float targetProgressComplete = 0;

    // Access Character Collisions
    public CharacterBehaviour bS;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ManageProgress(1.0f);

        // Establish Empty Speed
        // Set Thirst(Damage) Speed & Bar Color
        // Check Bar Status
        if (slider.value >= 3 * slider.maxValue / 4)
        {
            // Slow Damage
            emptySpeed = 0.0001f;
            // Bar Color
            fillImage.color = new Color(210f / 255f, 52f / 255f, 32f / 255f);
        }
        else if (slider.value <= 3 * slider.maxValue / 4 && slider.value >= slider.maxValue / 4)
        {
            // Medium Damage
            emptySpeed = 0.00015f;
            // Bar Color
            fillImage.color = new Color(138f / 255f, 30f / 255f, 56f / 255f);
        }
        else if (slider.value <= slider.maxValue / 4)
        {
            // Quick Damage
            emptySpeed = 0.0002f;
            // Bar Color
            fillImage.color = new Color(65f / 255f, 27f / 255f, 80f / 255f);
        }

        // Filling
        if (bS.isCollided) 
        {
            slider.value += bS.collisionResult * Time.deltaTime;      
        }
        else
        {
            slider.value -= emptySpeed * Time.deltaTime;
        }
    }

    public void ManageProgress(float newProgress)
    {
        if (bS.isCollided)
        {
            targetProgressComplete = slider.value + newProgress;
            
        }
        else if(!bS.isCollided)
        {
            targetProgress = slider.value + newProgress;
        }
        
    }

    public void changeScene(string sceneName)
    {
        if (slider.value <= 0.0f)
        {
            
        }
    }
}

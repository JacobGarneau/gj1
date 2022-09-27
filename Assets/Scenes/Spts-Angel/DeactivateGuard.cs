using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGuard : MonoBehaviour
{
    public bool isActive = true;
    public float TimeLeft = 5f;
    public bool TimerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // COLLISION TIMER
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else if(TimeLeft <= 0)
            {
                isActive = true;
                TimerOn = false;
                TimeLeft = 5f;
            }
        }
    }
}

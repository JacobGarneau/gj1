using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTarget : MonoBehaviour
{
    // Access Bar progress
    public GameObject target;
    public BarBehaviour bS;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Reset Target
        if (bS.isReset && !target.activeSelf)
        {
            target.SetActive(true);
        }
    }
}

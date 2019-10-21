using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textactive : MonoBehaviour
{

    public bool seen;

    private void FixedUpdate()
    {
    
        if( seen == false)
        {
            Debug.Log("gone");
            enabled = false;
        }
        else
        {
            Debug.Log("SIKE");
            enabled = true;
        }
    }
}

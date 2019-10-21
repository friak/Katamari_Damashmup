using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{ 
    public GameObject startSound;



    void Update()
    {


            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(startSound, transform.position, Quaternion.identity);
                SceneManager.LoadScene("battle_phase");
            }

        
    }
}

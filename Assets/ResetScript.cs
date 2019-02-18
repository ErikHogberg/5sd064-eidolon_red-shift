﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float exit = Input.GetAxis("Cancel");
        if (exit != 0)
        {
            Application.Quit();
        }

        float reset = Input.GetAxis("Submit");
        if (reset != 0)
        {
           Application.LoadLevel(Application.loadedLevel);
           
        }

    }
}

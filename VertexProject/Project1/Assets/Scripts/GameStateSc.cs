﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSc : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightMechanic : MonoBehaviour
{

    public bool isOn = false;
    public GameObject lightSource;
    public AudioSource clickSound;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("FKey"))
        {
            isOn = !isOn;
            lightSource.SetActive(isOn);
            clickSound.Play();
        }
    }
}

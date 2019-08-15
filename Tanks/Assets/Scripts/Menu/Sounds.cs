﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public Text txt;
    string txtBreaker;

    private void Start ()
    {
        slider.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);       

        if (PlayerPrefs.GetString("Sounds") != "on")
            txtBreaker = "Music off";
        else
            txtBreaker = "Music on";

        txt.text = txtBreaker;
    }
}

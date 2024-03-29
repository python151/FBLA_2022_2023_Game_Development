﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public static float initialTime;
    public float start_time;
    private TextMeshProUGUI component;
    public static float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        component = transform.GetComponent<TextMeshProUGUI>();
        
        time = start_time;
        initialTime = start_time;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0) {
            SceneManager.LoadSceneAsync("Scenes/GameOver");
        }
        component.text = time % 60 < 10 ? (int) time / 60 + ":0" + (int) time % 60 : (int) time / 60 + ":" + (int) time % 60;
    }
}

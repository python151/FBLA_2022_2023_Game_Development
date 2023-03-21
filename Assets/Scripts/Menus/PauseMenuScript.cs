using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool is_paused = false;

    public void Start()
    {
        is_paused = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !is_paused)
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("Scenes/PauseMenu", LoadSceneMode.Additive);
            is_paused = true;
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("Scenes/PauseMenu");
            is_paused = false;
        }
    }
}

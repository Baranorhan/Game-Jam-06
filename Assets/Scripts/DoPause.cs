using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoPause : MonoBehaviour
{
    public GameObject PauseUI;
    public static bool isPaused= false;
    public GameObject Pausebutton;

    // Update is called once per frame

    public void Pause()
    {
        PauseUI.SetActive(true);
        Pausebutton.SetActive(false);
        isPaused = true;
        Time.timeScale = 0f;
            }
    public void Resume()
    {
        PauseUI.SetActive(false);
        Pausebutton.SetActive(true);
        isPaused = false;
        Time.timeScale = 1f;

    }
}

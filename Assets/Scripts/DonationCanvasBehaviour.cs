using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DonationCanvasBehaviour : MonoBehaviour
{
    public bool restarting = false;
    public float timeToCount = 5;
    public TextMeshProUGUI timerText;
    void Update()
    {
        timeToCount -= Time.deltaTime;
        timerText.text = timeToCount.ToString("F1");
        if (restarting || !(timeToCount <= 0)) return;
        restarting = true;
        GameManager.instance.uiManager.RestartGame();
    }
}

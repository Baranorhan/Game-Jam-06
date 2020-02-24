using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    

    [Header("Canvas")]
    public GameObject gameOverCanvas;
    public GameObject gameWonCanvas;
    public GameObject gameCompletedCanvas;
    public GameObject gameRestartCanvas;
    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public float timer = 30.0f;
    
    [Header("Not used")]
    public TextMeshProUGUI e1firstSignText;
    public TextMeshProUGUI e1secondSignText;
    public TextMeshProUGUI e1thirdSignText;
    public TextMeshProUGUI e1resultText;
    public TextMeshProUGUI e2firstSignText;
    public TextMeshProUGUI e2secondSignText;
    public TextMeshProUGUI e2resultText;
    public TextMeshProUGUI e3firstSignText;
    public TextMeshProUGUI e3secondSignText;
    public TextMeshProUGUI e3resultText;

    public List<Image> eq1_1; 
    public List<Image> eq1_2; 
    public List<Image> eq1_3; 
    
    public List<Image> eq2_1; 
    public List<Image> eq2_2;
    
    public List<Image> eq3_1; 
    public List<Image> eq3_2;
    public void SetTexts(List<int> constants, List<int> results)
    {
        e1firstSignText.text = (constants[0] < 0 ? "-" : "");
        e1secondSignText.text = (constants[1] < 0 ? "-" : "+");
        e1thirdSignText.text = (constants[2] < 0 ? "-" : "+");
        e1resultText.text = results[0].ToString();
        
        e2firstSignText.text = (constants[3] < 0 ? "-" : "");
        e2secondSignText.text = (constants[4] < 0 ? "-" : "+");
        e2resultText.text = results[1].ToString();
        
        e3firstSignText.text = (constants[5] < 0 ? "-" : "");
        e3secondSignText.text = (constants[6] < 0 ? "-" : "+");
        e3resultText.text = results[2].ToString();
        
        SetActiveImages(eq1_1, constants[0]);
        SetActiveImages(eq1_2, constants[1]);
        SetActiveImages(eq1_3, constants[2]);
        SetActiveImages(eq2_1, constants[3]);
        SetActiveImages(eq2_2, constants[4]);
        SetActiveImages(eq3_1, constants[5]);
        SetActiveImages(eq3_2, constants[6]);
    }

    public void SetActiveImages(List<Image> images, int constant)
    {
        if (Math.Abs(constant) == 1)
        {
            images[0].gameObject.SetActive(false);
            images[1].gameObject.SetActive(true);
            images[2].gameObject.SetActive(false);
            return;
        }
        if (Math.Abs(constant) == 2)
        {
            images[0].gameObject.SetActive(true);
            images[1].gameObject.SetActive(true);
            images[2].gameObject.SetActive(false);
            return;
        }
        images[0].gameObject.SetActive(true);
        images[1].gameObject.SetActive(true);
        images[2].gameObject.SetActive(true);
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F1");
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }

    public void OnMainMenuTapped()
    {
        
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRestartTapped()
    {
        RestartLevel();
    }

    public void GameWon()
    {
        gameWonCanvas.SetActive(true);
    }

    public void StartNextLevel()
    {
        var currentIndex = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.GetActiveScene().name == "Level-6")
        {
            GameCompleted();
            return;
        }

        SceneManager.LoadScene(currentIndex + 1);
    }

    private void GameCompleted()
    {
        gameCompletedCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level-1-Tutorial");
    }

    public void RestartLevel()
    {
        
        SceneManager.LoadScene(GameManager.instance.sceneName);
    }

    public void OnDonateTapped()
    {
        gameWonCanvas.SetActive(false);
        gameRestartCanvas.SetActive(true);
    }
}

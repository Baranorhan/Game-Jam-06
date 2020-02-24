using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [Header("Item Creation")]
    public MassGiver massGiver;
    public EquationGenerator3 equationGenerator3;
    public UiManager uiManager;
    public List<int> constants;
    public List<int> results;
    public List<ColorPalette> colorPalettes;
    public ColorPalette colors;

    public string sceneName;
    [Header("Game Variables")]
    public int totalArrows;
    public float gameOverCounter;
    public int itemCount;
    public int itemsCountToWin;
    public bool gameWon;
    public bool gameOver;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }

        Initialize();
    }

    private void Initialize()
    {
        Time.timeScale = 1;
        CheckOptionsSave();
        
        constants = equationGenerator3.GenerateEquationConstants();
        results = new List<int>();
        var value = constants[0] * massGiver.cubeMass + constants[1] * massGiver.triangleMass +
                    constants[2] * massGiver.circleMass;
        Debug.Log("[] = "+ massGiver.cubeMass + "   △ = " + massGiver.triangleMass +"   O = " + massGiver.circleMass);
        Debug.Log( (constants[0]<0 ? "-" : "" )+ (constants[0]==1 ? "" : constants[0].ToString() ) + "[] " + 
                   (constants[1]<0 ? "-" : "+" ) + (constants[1]==1 ? "" : constants[1].ToString() )+"△ " + 
                   (constants[2]<0 ? "-" : "+" ) +(constants[2]==1 ? "" : constants[2].ToString() ) + "O = " + value);
        
        
        var value2 = constants[3] * massGiver.cubeMass + constants[4] * massGiver.triangleMass ;
        
        Debug.Log( (constants[3]<0 ? "-" : "" )+ (constants[3]==1 ? "" : constants[3].ToString() ) + "[] " + 
                   (constants[4]<0 ? "-" : "+" ) + (constants[4]==1 ? "" : constants[4].ToString() )+"△ " +" = " + value2);
        var value3 = constants[5] * massGiver.triangleMass + constants[6] * massGiver.circleMass ;
        
        Debug.Log( (constants[5]<0 ? "-" : "" )+ (constants[5]==1 ? "" : constants[5].ToString() ) + "△ " + 
                   (constants[6]<0 ? "-" : "+" ) + (constants[6]==1 ? "" : constants[6].ToString() )+"O " +" = " + value3);
        results.Add(value);
        results.Add(value2);
        results.Add(value3);
        uiManager.SetTexts(constants, results);
    }

    private void CheckOptionsSave()
    {
        if (!PlayerPrefs.HasKey("ColorIndex"))
        {
            PlayerPrefs.SetInt("ColorIndex", 0);
            colors = colorPalettes[0];
            return;
        }

        var paletteIndex = PlayerPrefs.GetInt("ColorIndex");
        if (paletteIndex != 1)
        {
            colors = colorPalettes[paletteIndex];
            return;
        }

        paletteIndex = Random.Range(1, 4);
        colors = colorPalettes[paletteIndex];
    }

    public void LeftSideTapped()
    {
        Debug.Log("Left side tapped.");
    }
    public void RightSideTapped()
    {
        Debug.Log("Right side tapped.");
    }

    public void ShootArrow()
    {
        if (totalArrows <= 0)
        {
            return;
        }

        totalArrows--;
        if (totalArrows <= 0)
        {
            StartCoroutine(GameOverAfterDelay());
        }
        
    }

    IEnumerator  GameOverAfterDelay()
    {
        yield return  new WaitForSeconds(gameOverCounter);
        if(!gameWon && !gameOver)
            GameOver();
    }

    public void GameOver()
    {
        if(!gameWon && !gameOver)
        gameOver = true;
        uiManager.GameOver();
    }

    public void ItemDroppedOut()
    {
        itemCount--;
        
    }
    public void ItemDroppedIn()
    {

        if (gameWon || gameOver) return;
        itemCount++;
        if (itemCount < itemsCountToWin) return;
        gameWon = true;
        uiManager.GameWon();
    }

    private void Update()
    {
        if (gameWon && !gameOver)
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                uiManager.StartNextLevel();
            }
        }
    }
}

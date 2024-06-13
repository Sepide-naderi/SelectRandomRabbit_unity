using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class ColorItem
{
    public string Label;
    public Color ColorValue;
}

public class Game_Controler : MonoBehaviour
{
    public List<ColorItem> ColorsList;
    public TextMeshProUGUI DisplayColorName;

    public Image RightButtons, LeftButtons, TopButtons, BottomButtons;

    private int targetIndex;

    [Header("Score Settings:")]
    public int CurrentScore;
    public TextMeshProUGUI ScoreDisplay;

    [Header("Sound Effects:")]
    public AudioSource SuccessSound;
    public AudioSource FailSound;

    [Header("Timer Settings:")]
    public TextMeshProUGUI TimerDisplay;
    public float MaxTime = 5;
    public bool isTimerRunning = false;
    public float delayTime = 3;

    [Header("Panels : ")]

    public GameObject Loss_Panel;
    public GameObject Win_Panel;


    void Start()
    {
        ScoreDisplay.text = "score is:" + "0";
        InitializeGame();
    }

    
}
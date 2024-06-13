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

    private void InitializeGame()
    {
        AssignRandomColors(); 
    }

    private void AssignRandomColors()
    {
        int[] randomIndices = new int[4];
        for (int i = 0; i < 4; i++)
        {
            randomIndices[i] = UnityEngine.Random.Range(0, ColorsList.Count);
        }

        if (randomIndices[0] != randomIndices[1] && randomIndices[0] != randomIndices[2] && randomIndices[0] != randomIndices[3] &&
            randomIndices[1] != randomIndices[2] && randomIndices[1] != randomIndices[3] &&
            randomIndices[2] != randomIndices[3])
        {
            SetButtonColors(RightButtons, randomIndices[0]);
            SetButtonColors(LeftButtons, randomIndices[1]);
            SetButtonColors(TopButtons, randomIndices[2]);
            SetButtonColors(BottomButtons, randomIndices[3]);
        }
        else
        {
            AssignRandomColors();
        }

        int chosenColorIndex = UnityEngine.Random.Range(0, randomIndices.Length);
        targetIndex = randomIndices[chosenColorIndex];

        DisplayColorName.text = ColorsList[targetIndex].Label;
        Invoke("StartGameAfterDelay", delayTime);
    }

    private void SetButtonColors(Image Box, int index)
    {
        Box.GetComponent<Image>().color = ColorsList[index].ColorValue;

        Box.GetComponent<Butten_Controler>().ColorLabel = ColorsList[index].Label;

    }

    private void StartGameAfterDelay()
    {
        isTimerRunning = true;
    }

    void Update()
    {
        UpdateTimer();
    }

    public void ValidateColor(string selectedColor)
    {
        if (selectedColor == ColorsList[targetIndex].Label)
        {
            SuccessSound.Play();

            UpdateScore(5);
            MaxTime = 10;
        }
        else
        {
            FailSound.Play();
            UpdateScore(-5);
            MaxTime = 10;
        }

        AssignRandomColors();
    }

    private void UpdateScore(int change)
    {
        CurrentScore += change;

        if (CurrentScore >= 100)
        {
            Win_Panel.SetActive(true);
            ScoreDisplay.text = CurrentScore.ToString();
            isTimerRunning = false;
        }
        else
        {



            if (CurrentScore <= 0)
            {
                CurrentScore = 0;

                Loss_Panel.SetActive(true);

                ScoreDisplay.text = CurrentScore.ToString();
                isTimerRunning = false;

            }
            else
            {
                ScoreDisplay.text = CurrentScore.ToString();
                isTimerRunning = false;

                TimerDisplay.text = "";

            }

            CancelInvoke();
        }
    }

    private void UpdateTimer()
    {
        if (isTimerRunning)
        {
            MaxTime -= Time.deltaTime;

            if (MaxTime <= 0)
            {
                UpdateScore(-5);
                MaxTime = 5;
                AssignRandomColors();
            }

            TimerDisplay.text = "Timer: " + MaxTime.ToString("N2");
        }
    }


    public void Reset_The_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
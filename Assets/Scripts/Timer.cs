using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Timer : MonoBehaviour
{
    public float TimeRemaining;
    float StartingTime;
    float StartingScale;
    public RectTransform TimerBar;
    public Image bar;

    ////////////////Other Scripts

    public GameManager GameManager;
    public ScoreManager ScoreManager;

    void Start()
    {
        StartingTime = TimeRemaining;           //Set StartingTime to TimeRemaining, TimeRemaining can be adjusted in the Inspector.
        StartingScale = TimerBar.localScale.x;  //The StartingScale is the .x of the TimerBar in the Scene's Canvas.
    }

    void Update()
    {
        TimerToggle();

        startGameTimer();

        if (startGame)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                ResetTime();    // Resets to 40 seconds.
            }

            if (TimerCountDown) // Timer Pause Cheat [Toggle]
            {
                CountDownTimer();
            }
        }
    }

    public void CountDownTimer()
    {
        if (TimeRemaining > 0)  //TimeRemaining more than 0.
        {
            float Scale = (TimeRemaining / StartingTime);    //To get the Scale of the TimerBar. Notes: 10/10 = 1, 5/10 = 0.5, 0/10 = 0, etc. (You get ratios).
            float NewXScale = StartingScale * Scale;         //Multiple the Starting scale by the Scale (Ratio).
            TimerBar.localScale = new Vector2(NewXScale, 1); //Set the scale of TimerBar.
            TimeRemaining -= Time.deltaTime;                 //Minus 1 Second.
        }

        if (TimeRemaining <= 0) //TimeRemaining less than or equal to 0.
        {
            int finalScore = GameManager.score;         // From GameManager
            ScoreManager.UpdateScore(finalScore);       // Sent to ScoreManager

            Debug.LogWarning("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //Cheats
    public void ResetTime()
    {
        TimeRemaining = 40.0f;
    }

    bool TimerCountDown = true;

    public void TimerToggle()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TimerCountDown = !TimerCountDown;
            Debug.Log("Timer Count down: " + TimerCountDown);
        }
    }

    bool startGame = false;
    float startTimer = 2.0f;

    void startGameTimer()
    {
        startTimer -= Time.deltaTime;

        Debug.Log(startTimer);

        if (startTimer <= 0)
        {
            startGame = true;
        }
    }
}

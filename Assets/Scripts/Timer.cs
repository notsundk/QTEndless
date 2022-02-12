using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float TimeRemaining;
    float StartingTime;
    float StartingScale;
    public RectTransform TimerBar;
    public Image bar;

    void Start()
    {
        StartingTime = TimeRemaining;           //Set StartingTime to TimeRemaining, TimeRemaining can be adjusted in the Inspector.
        StartingScale = TimerBar.localScale.x;  //The StartingScale is the .x of the TimerBar in the Scene's Canvas.
    }

    void Update()
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
            Debug.LogWarning("Game Over");  
        }
    }
}

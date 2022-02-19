using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.GetInt("HighScore", 0);         // similar to the one in Brackey's video
        PlayerPrefs.GetInt("CurrentScore", 0);
        PlayerPrefs.GetInt("NewHighScore", 0);
    }

    public void UpdateScore(int finalScore) // finalScore sent from Timer.cs
    {
        PlayerPrefs.SetInt("CurrentScore", finalScore);

        if (finalScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", finalScore);
            PlayerPrefs.SetInt("NewHighScore", 1);
        }
    }
}

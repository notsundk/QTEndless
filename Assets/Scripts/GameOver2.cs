using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver2 : MonoBehaviour
{
    [SerializeField] TextMeshPro score;
    [SerializeField] TextMeshPro highScore;

    public GameObject NewHighScore;

    private void Start()
    {
        if (PlayerPrefs.GetInt("NewHighScore", 0) == 1)
        {
            NewHighScore.SetActive(true);
        }

        PlayerPrefs.SetInt("NewHighScore", 0);
    }

    void Update()
    {
        score.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();  // Scripts are destroy when scene are changed.
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}

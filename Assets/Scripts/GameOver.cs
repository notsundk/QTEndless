using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    //[SerializeField] TextMeshPro score;
    //[SerializeField] TextMeshPro highScore;

    void Update()
    {
        Restart();
        Reset();
    }

    //public void YourScore(int finalScore)
    //{
    //    score.text = finalScore.ToString();
    //}
        
    //public void HighScore(int highhighScore)
    //{
    //    highScore.text = highhighScore.ToString();
    //}

    public void Reset()
    {
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
    }

    public void TryAgain()
    {
        Debug.Log("Try Again Button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Return To Main Menu Button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}

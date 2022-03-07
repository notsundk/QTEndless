using System.Collections;               // What is this for?
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      // For Changing Scenes
using TMPro;                            // For Text Mesh Pro

public class GameManager : MonoBehaviour
{
    // "GameManager" manages all game logic

    string[] button = new string[4];                            // Array of all buttons: Triangle, Square, Circle, Cross
    int sequenceLength = 4;                                     // How long is the QTE sequence, value should depend on "how well the player is doing"
    public List<string> buttonSequence = new List<string>();    // List of the button sequence, to be shown in game.

    int currentPos = 0;     // If currentPos = finalPos, then player score
    int finalPos = 4;       // there are 4 button in a sequence, so going to the "next" button after 4 should score. 
    bool incorrect = false; // (incorrect = false) == correct

    public int score = 0;

    ///////////////////////////////////////// Combo Timer

    [Header("Combo Game Elements")]
    int Multiplier = 0;
    public TextMeshPro ComboText;

    public float TimeRemaining;
    float StartingTime;
    float StartingScale;
    public RectTransform TimerBar;
    public Image bar;

    ///////////////////////////////////////// Graphical Elements

    [Header("Score Text Elements")]
    public TextMeshPro ScoreText;

    [Header("Button Display Reference")]
    public GameObject Pos1Up;
    public GameObject Pos1Down;
    public GameObject Pos1Left;
    public GameObject Pos1Right;

    public GameObject Pos2Up;
    public GameObject Pos2Down;
    public GameObject Pos2Left;
    public GameObject Pos2Right;

    public GameObject Pos3Up;
    public GameObject Pos3Down;
    public GameObject Pos3Left;
    public GameObject Pos3Right;

    public GameObject Pos4Up;
    public GameObject Pos4Down;
    public GameObject Pos4Left;
    public GameObject Pos4Right;

    [Header("Indicator Display Reference")]
    public GameObject Pos1Checkmark;
    public GameObject Pos2Checkmark;
    public GameObject Pos3Checkmark;
    public GameObject Pos4Checkmark;

    [Header("Sound Source")]
    public GameObject CorrectSound;
    public GameObject InCorrectSound;
    public GameObject AllCorrectSound;

    /////////////////////////////////////////
    //Other Scripts

    public Timer Timer;

    private void Awake()
    {
        // Adding buttons to button array
        button[0] = "Up";
        button[1] = "Down";
        button[2] = "Left";
        button[3] = "Right";

        StartingTime = TimeRemaining;
        StartingScale = TimerBar.localScale.x;

        resetSequence();    // Generating the First QTE Sequence
    }

    private void Start()
    {

    }

    private void Update()
    {
            // Gameplay
            sequenceDisplay();      //Display QTE Button Sequence
            playerControls();       //Player Controls
            updateScore();          //Update Score String
            updateCombo();          //Update Combo String
            Restart();              //Quick Restart

            // Debug Functions below, press...
            //SoundCheck();           //Q
            //buttonDisplayCheck();   //A
            //printCurrentPos();      //D
            //printButtonSequence();  //F
            //resetPlayerScore();     //S
            //resetButtonSequence();  //Space

            // Cheats
            ComboDrainToggle();
            resetButtonSequence();
    }

    void resetSequence() // Resets Button Sequence List
    {
        buttonSequence = new List<string>();    // Get new List

        for (int i = 0; i < sequenceLength; i++)
        {
            buttonSequence.Add(button[Random.Range(0, 4)]);
            //Debug.Log(buttonSequence[i]);
        }
    }

    void sequenceDisplay()
    {
        // Button Postion 1
        if (buttonSequence[0] == "Up")
        {
            Pos1Up.SetActive(true);
            Pos1Down.SetActive(false);
            Pos1Left.SetActive(false);
            Pos1Right.SetActive(false);
        }
        else if (buttonSequence[0] == "Down")
        {
            Pos1Up.SetActive(false);
            Pos1Down.SetActive(true);
            Pos1Left.SetActive(false);
            Pos1Right.SetActive(false);
        }
        else if (buttonSequence[0] == "Left")
        {
            Pos1Up.SetActive(false);
            Pos1Down.SetActive(false);
            Pos1Left.SetActive(true);
            Pos1Right.SetActive(false);
        }
        else if (buttonSequence[0] == "Right")
        {
            Pos1Up.SetActive(false);
            Pos1Down.SetActive(false);
            Pos1Left.SetActive(false);
            Pos1Right.SetActive(true);
        }

        // Button Postion 2
        if (buttonSequence[1] == "Up")
        {
            Pos2Up.SetActive(true);
            Pos2Down.SetActive(false);
            Pos2Left.SetActive(false);
            Pos2Right.SetActive(false);
        }
        else if (buttonSequence[1] == "Down")
        {
            Pos2Up.SetActive(false);
            Pos2Down.SetActive(true);
            Pos2Left.SetActive(false);
            Pos2Right.SetActive(false);
        }
        else if (buttonSequence[1] == "Left")
        {
            Pos2Up.SetActive(false);
            Pos2Down.SetActive(false);
            Pos2Left.SetActive(true);
            Pos2Right.SetActive(false);
        }
        else if (buttonSequence[1] == "Right")
        {
            Pos2Up.SetActive(false);
            Pos2Down.SetActive(false);
            Pos2Left.SetActive(false);
            Pos2Right.SetActive(true);
        }

        // Button Postion 3
        if (buttonSequence[2] == "Up")
        {
            Pos3Up.SetActive(true);
            Pos3Down.SetActive(false);
            Pos3Left.SetActive(false);
            Pos3Right.SetActive(false);
        }
        else if (buttonSequence[2] == "Down")
        {
            Pos3Up.SetActive(false);
            Pos3Down.SetActive(true);
            Pos3Left.SetActive(false);
            Pos3Right.SetActive(false);
        }
        else if (buttonSequence[2] == "Left")
        {
            Pos3Up.SetActive(false);
            Pos3Down.SetActive(false);
            Pos3Left.SetActive(true);
            Pos3Right.SetActive(false);
        }
        else if (buttonSequence[2] == "Right")
        {
            Pos3Up.SetActive(false);
            Pos3Down.SetActive(false);
            Pos3Left.SetActive(false);
            Pos3Right.SetActive(true);
        }

        // Button Postion 4
        if (buttonSequence[3] == "Up")
        {
            Pos4Up.SetActive(true);
            Pos4Down.SetActive(false);
            Pos4Left.SetActive(false);
            Pos4Right.SetActive(false);
        }
        else if (buttonSequence[3] == "Down")
        {
            Pos4Up.SetActive(false);
            Pos4Down.SetActive(true);
            Pos4Left.SetActive(false);
            Pos4Right.SetActive(false);
        }
        else if (buttonSequence[3] == "Left")
        {
            Pos4Up.SetActive(false);
            Pos4Down.SetActive(false);
            Pos4Left.SetActive(true);
            Pos4Right.SetActive(false);
        }
        else if (buttonSequence[3] == "Right")
        {
            Pos4Up.SetActive(false);
            Pos4Down.SetActive(false);
            Pos4Left.SetActive(false);
            Pos4Right.SetActive(true);
        }
    }   // "your method is repulsive", "put the shapes into a list" - Champ

    void playerControls()
    {
        if (!incorrect) // Check if player is NOT incorrect
        {
            if (Input.GetKeyDown(KeyCode.W) && buttonSequence[currentPos] == "Up" || Input.GetKeyDown(KeyCode.UpArrow) && buttonSequence[currentPos] == "Up")       // Check if Triangle button is pressed && button in the currentPos of the button Sequence = Triangle, then currentPos + 1
            {
                Debug.Log("Correct Button Pressed! [Up Arrow]");
                if (currentPos == 0)
                {
                    if (!incorrect)
                    {
                        Pos1Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 1)
                {
                    if (!incorrect)
                    {
                        Pos2Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 2)
                {
                    if (!incorrect)
                    {
                        Pos3Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 3)
                {
                    if (!incorrect)
                    {
                        Pos4Checkmark.SetActive(true);
                        AllCorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                currentPos++;
            }
            else if (Input.GetKeyDown(KeyCode.S) && buttonSequence[currentPos] == "Down" || Input.GetKeyDown(KeyCode.DownArrow) && buttonSequence[currentPos] == "Down")
            {
                Debug.Log("Correct Button Pressed! [Down Arrow]");
                if (currentPos == 0)
                {
                    if (!incorrect)
                    {
                        Pos1Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 1)
                {
                    if (!incorrect)
                    {
                        Pos2Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 2)
                {
                    if (!incorrect)
                    {
                        Pos3Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 3)
                {
                    if (!incorrect)
                    {
                        Pos4Checkmark.SetActive(true);
                        AllCorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                currentPos++;
            }
            else if (Input.GetKeyDown(KeyCode.A) && buttonSequence[currentPos] == "Left" || Input.GetKeyDown(KeyCode.LeftArrow) && buttonSequence[currentPos] == "Left")
            {
                Debug.Log("Correct Button Pressed! [Left Arrow]");
                if (currentPos == 0)
                {
                    if (!incorrect)
                    {
                        Pos1Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 1)
                {
                    if (!incorrect)
                    {
                        Pos2Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 2)
                {
                    if (!incorrect)
                    {
                        Pos3Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 3)
                {
                    if (!incorrect)
                    {
                        Pos4Checkmark.SetActive(true);
                        AllCorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                currentPos++;
            }
            else if (Input.GetKeyDown(KeyCode.D) && buttonSequence[currentPos] == "Right" || Input.GetKeyDown(KeyCode.RightArrow) && buttonSequence[currentPos] == "Right")
            {
                Debug.Log("Correct Button Pressed! [Right Arrow]");
                if (currentPos == 0)
                {
                    if (!incorrect)
                    {
                        Pos1Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 1)
                {
                    if (!incorrect)
                    {
                        Pos2Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 2)
                {
                    if (!incorrect)
                    {
                        Pos3Checkmark.SetActive(true);
                        CorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                else if (currentPos == 3)
                {
                    if (!incorrect)
                    {
                        Pos4Checkmark.SetActive(true);
                        AllCorrectSound.GetComponent<AudioSource>().Play();
                    }
                }
                currentPos++;
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Wrong Button Pressed!");
                incorrect = true;
            }
        }

        if (incorrect) // Check if player is incorrect
        {
            // Reset Indicator
            Pos1Checkmark.SetActive(false);
            Pos2Checkmark.SetActive(false);
            Pos3Checkmark.SetActive(false);
            Pos4Checkmark.SetActive(false);

            // Sound
            InCorrectSound.GetComponent<AudioSource>().Play();

            // Punishment
            Multiplier = 0;
            incorrect = false;
            currentPos = 0;
            Debug.Log("Incorrect, resetting currentPos to 0");
        }
    }

    void updateCombo()  // Update Combo Timer
    {
        ComboText.text = Multiplier.ToString();

        if (!ComboDrain)
        {
            if (TimeRemaining > 0)
            {
                float Scale = (TimeRemaining / StartingTime);
                float NewXScale = StartingScale * Scale;
                TimerBar.localScale = new Vector2(NewXScale, 1);
                TimeRemaining -= Time.deltaTime;
            }

            if (TimeRemaining <= 0)
            {
                Multiplier = 0;
                TimeRemaining = StartingTime;
                Debug.Log("Time out! New QTE Sequence Genereted!");
            }
        }
    }

    void updateScore()
    {
        ScoreText.text = score.ToString();

        if (currentPos == finalPos)
        {
            TimeRemaining = StartingTime;

            if (Multiplier == 0)
            {
                score += 1;
                Multiplier += 1;
            }
            else
            {
                score += Multiplier;
                Multiplier += 1;
            }

            currentPos = 0;
            resetSequence();
            Debug.Log("Score: " + score);

            Pos1Checkmark.SetActive(false);
            Pos2Checkmark.SetActive(false);
            Pos3Checkmark.SetActive(false);
            Pos4Checkmark.SetActive(false);
        }
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Restart");
        }
    }

    //////////// CHEATS ////////////

    bool ComboDrain = false;

    void ComboDrainToggle()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //if (!ComboDrain)    // Turn on Combo Drain
            //{
            //    ComboDrain = true;
            //    Debug.Log("Combo WILL Drain");
            //    return;
            //}
            //if (ComboDrain)     // Turn off Combo Drain
            //{
            //    ComboDrain = !true;
            //    Debug.Log("Combo WON'T Drain");
            //    return;
            //}

            ComboDrain = !ComboDrain;
        }
    }

    void resetButtonSequence()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            resetSequence();
        }
    }

    //////////// DEBUG ////////////

    //void SoundCheck()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        gameObject.GetComponent<AudioSource>().Play();
    //        Debug.Log("Q Pressed, Play Sound");
    //    }
    //}

    //void buttonDisplayCheck()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        Pos1Up.SetActive(true);
    //    }
    //}

    //void printCurrentPos()
    //{
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        Debug.Log("D Pressed, Current Pos: " + currentPos);
    //    }
    //}

    //void printButtonSequence()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        Debug.Log("F Pressed, Printing QTE Button Sequence");

    //        for (int i = 0; i < sequenceLength; i++)
    //        {
    //            Debug.Log(buttonSequence[i]);
    //        }
    //    }
    //}

    //void resetPlayerScore()
    //{
    //    {
    //        if (Input.GetKeyDown(KeyCode.S))
    //        {
    //            Debug.Log("S Pressed, Reset Player Score");
    //            score = 0;
    //        }
    //    }
    //}

    //void resetButtonSequence()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Debug.Log("Space Pressed, Reset QTE Button Sequence");
    //        resetSequence();
    //    }
    //}
}

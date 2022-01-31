using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // "GameManager" manages all game logic

    string[] button = new string[4];                            // Array of all buttons: Triangle, Square, Circle, Cross
    int sequenceLength = 4;                                     // How long is the QTE sequence, value should depend on "how well the player is doing"
    public List<string> buttonSequence = new List<string>();    // List of the button sequence, to be shown in game.

    int currentPos = 0;     // If currentPos = finalPos, then player score
    int finalPos = 4;       // there are 4 button in a sequence, so going to the "next" button after 4 should score. 
    bool incorrect = false;

    int health = 3;         // The player have 3 hp.
    float maxTime = 5;      // In seconds, the time the player have to input the sequence correctly.
    float damageTime = 0;   // If maxTime = damageTime, then health - 1.

    int score = 0;

    public Text ScoreText;

    // Button Reference
    public GameObject Pos1Triangle;
    public GameObject Pos1Square;
    public GameObject Pos1Circle;
    public GameObject Pos1Cross;

    public GameObject Pos2Triangle;
    public GameObject Pos2Square;
    public GameObject Pos2Circle;
    public GameObject Pos2Cross;

    public GameObject Pos3Triangle;
    public GameObject Pos3Square;
    public GameObject Pos3Circle;
    public GameObject Pos3Cross;

    public GameObject Pos4Triangle;
    public GameObject Pos4Square;
    public GameObject Pos4Circle;
    public GameObject Pos4Cross;

    private void Awake()
    {
        // Adding buttons to button array
        button[0] = "Triangle";
        button[1] = "Square";
        button[2] = "Circle";
        button[3] = "Cross";

        resetSequence();    // Generating the First QTE Sequence
    }

    private void Update()
    {
        // Gameplay
        sequenceDisplay();
        playerControls();
        updateScore();
        timeLimit();
        deathCheck();

        // Debug Functions below, press...
        buttonCheck();          //A
        printCurrentPos();      //D
        printButtonSequence();  //F
        resetPlayerScore();     //S
        resetButtonSequence();  //Space
    }

    void resetSequence() // Resets Button Sequence List
    {
        buttonSequence = new List<string>();    // Get new List

        for (int i = 0; i < sequenceLength; i++)
        {
            buttonSequence.Add(button[Random.Range(0, 4)]);
            Debug.Log(buttonSequence[i]);
        }
    }

    void sequenceDisplay()
    {
        // Button Postion 1
        if (buttonSequence[0] == "Triangle")
        {
            Pos1Triangle.SetActive(true);
            Pos1Square.SetActive(false);
            Pos1Circle.SetActive(false);
            Pos1Cross.SetActive(false);
        }
        else if (buttonSequence[0] == "Square")
        {
            Pos1Triangle.SetActive(false);
            Pos1Square.SetActive(true);
            Pos1Circle.SetActive(false);
            Pos1Cross.SetActive(false);
        }
        else if (buttonSequence[0] == "Circle")
        {
            Pos1Triangle.SetActive(false);
            Pos1Square.SetActive(false);
            Pos1Circle.SetActive(true);
            Pos1Cross.SetActive(false);
        }
        else if (buttonSequence[0] == "Cross")
        {
            Pos1Triangle.SetActive(false);
            Pos1Square.SetActive(false);
            Pos1Circle.SetActive(false);
            Pos1Cross.SetActive(true);
        }

        // Button Postion 2
        if (buttonSequence[1] == "Triangle")
        {
            Pos2Triangle.SetActive(true);
            Pos2Square.SetActive(false);
            Pos2Circle.SetActive(false);
            Pos2Cross.SetActive(false);
        }
        else if (buttonSequence[1] == "Square")
        {
            Pos2Triangle.SetActive(false);
            Pos2Square.SetActive(true);
            Pos2Circle.SetActive(false);
            Pos2Cross.SetActive(false);
        }
        else if (buttonSequence[1] == "Circle")
        {
            Pos2Triangle.SetActive(false);
            Pos2Square.SetActive(false);
            Pos2Circle.SetActive(true);
            Pos2Cross.SetActive(false);
        }
        else if (buttonSequence[1] == "Cross")
        {
            Pos2Triangle.SetActive(false);
            Pos2Square.SetActive(false);
            Pos2Circle.SetActive(false);
            Pos2Cross.SetActive(true);
        }

        // Button Postion 3
        if (buttonSequence[2] == "Triangle")
        {
            Pos3Triangle.SetActive(true);
            Pos3Square.SetActive(false);
            Pos3Circle.SetActive(false);
            Pos3Cross.SetActive(false);
        }
        else if (buttonSequence[2] == "Square")
        {
            Pos3Triangle.SetActive(false);
            Pos3Square.SetActive(true);
            Pos3Circle.SetActive(false);
            Pos3Cross.SetActive(false);
        }
        else if (buttonSequence[2] == "Circle")
        {
            Pos3Triangle.SetActive(false);
            Pos3Square.SetActive(false);
            Pos3Circle.SetActive(true);
            Pos3Cross.SetActive(false);
        }
        else if (buttonSequence[2] == "Cross")
        {
            Pos3Triangle.SetActive(false);
            Pos3Square.SetActive(false);
            Pos3Circle.SetActive(false);
            Pos3Cross.SetActive(true);
        }

        // Button Postion 4
        if (buttonSequence[3] == "Triangle")
        {
            Pos4Triangle.SetActive(true);
            Pos4Square.SetActive(false);
            Pos4Circle.SetActive(false);
            Pos4Cross.SetActive(false);
        }
        else if (buttonSequence[3] == "Square")
        {
            Pos4Triangle.SetActive(false);
            Pos4Square.SetActive(true);
            Pos4Circle.SetActive(false);
            Pos4Cross.SetActive(false);
        }
        else if (buttonSequence[3] == "Circle")
        {
            Pos4Triangle.SetActive(false);
            Pos4Square.SetActive(false);
            Pos4Circle.SetActive(true);
            Pos4Cross.SetActive(false);
        }
        else if (buttonSequence[3] == "Cross")
        {
            Pos4Triangle.SetActive(false);
            Pos4Square.SetActive(false);
            Pos4Circle.SetActive(false);
            Pos4Cross.SetActive(true);
        }
    }   // "your method is repulsive", "put the shapes into a list" - Champ

    void playerControls()
    {
        if (!incorrect) // Check if player is NOT incorrect
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && buttonSequence[currentPos] == "Triangle")       // Check if Triangle button is pressed && button in the currentPos of the button Sequence = Triangle, then currentPos + 1
            {
                Debug.Log("Correct Button Pressed! Triangle (Up Arrow)");
                currentPos++;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && buttonSequence[currentPos] == "Square")
            {
                Debug.Log("Correct Button Pressed! Square (Down Arrow)");
                currentPos++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && buttonSequence[currentPos] == "Circle")
            {
                Debug.Log("Correct Button Pressed! Circle (Left Arrow)");
                currentPos++;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && buttonSequence[currentPos] == "Cross")
            {
                Debug.Log("Correct Button Pressed! Cross (Right Arrow)");
                currentPos++;
            }
            else if ( (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.RightArrow)) )
            {
                Debug.Log("Wrong Button Pressed!");
                incorrect = true;
            }
        }

        if (incorrect) // Check if player is incorrect
        {
            incorrect = false;
            currentPos = 0;
            Debug.Log("Incorrect, resetting currentPos to 0");
        }
    }

    void updateScore()
    {
        ScoreText.text = score.ToString();

        if (currentPos == finalPos)
        {
            score++;
            currentPos = 0;
            resetSequence();
            Debug.Log("Score: " + score);
        }
    }

    void timeLimit()
    {
        // Timer insert here

        if (maxTime == damageTime)
        {
            resetSequence();
            maxTime = 5;
            health--;
            currentPos = 0;
            Debug.Log("Time out! New QTE Sequence Genereted!");
        }
    }

    void deathCheck()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
        }
    }

    //////////// DEBUG ////////////

    void buttonCheck()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Pos1Circle.SetActive(true);
        }
    }

    void printCurrentPos()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D Pressed, Current Pos: " + currentPos);
        }
    }

    void printButtonSequence()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F Pressed, Printing QTE Button Sequence");

            for (int i = 0; i < sequenceLength; i++)
            {
                Debug.Log(buttonSequence[i]);
            }
        }
    }

    void resetPlayerScore()
    {
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("S Pressed, Reset Player Score");
                score = 0;
            }
        }
    }

    void resetButtonSequence()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Pressed, Reset QTE Button Sequence");
            resetSequence();
        }
    }
}

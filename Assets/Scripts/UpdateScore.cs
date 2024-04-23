using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TMP_Text scoreText; 

    public static int score = 0; //Current score value
    private float timer = 0f; //Timer to track elapsed time

    void Update()
    {
        //Increment the timer
        timer += Time.deltaTime;

        //If one second has elapsed, update the score and reset the timer
        if (timer >= 1f)
        {
            score += 1; //Increment the score
            UpdateScoreText(); //Update the score text
            timer = 0f; //Reset the timer
        }
    }

    //Update the UI Text element with the current score value
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    //Method to update the score
    public static void ChangeScore(int value)
    {
        score = value;
    }

    //Method to retrieve the score
    public static int GetScore()
    {
        return score;
    }
}

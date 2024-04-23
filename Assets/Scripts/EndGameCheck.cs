using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCheck : MonoBehaviour
{
    public float endGameYThreshold = -10f; //Y-coordinate threshold to trigger end game
    private bool gameOver = false; //Flag to prevent multiple end game triggers

    void Update()
    {
        //Check if the character's Y-coordinate falls below the threshold
        if (transform.position.y < endGameYThreshold && !gameOver)
        {
            //Trigger end game screen
            EndGame();
        }
    }

    void EndGame()
    {
        //Set the gameOver flag to prevent multiple triggers
        gameOver = true;

        //Load end game scene
        SceneManager.LoadScene("EndGameScene");
    }
}

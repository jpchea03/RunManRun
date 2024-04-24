using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCheck : MonoBehaviour
{
    public float endGameYThreshold = -10f; //Y-coordinate threshold to trigger end game
    private bool gameOver = false; //Flag to prevent multiple end game triggers
    private float leftBoundary; //Dynamically changing left boundary


    void Start()
    {
        //Set the initial left boundary based on the left edge of the camera's viewport
        leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x;
    }

    void Update()
    {

        UpdateLeftBoundary();
        
        //Check if the character's Y-coordinate falls below the threshold
        if ((transform.position.y < endGameYThreshold && !gameOver) || (transform.position.x < leftBoundary && !gameOver))
        {
            //Trigger end game screen
            EndGame();
        }
    }

    void UpdateLeftBoundary()
    {
        //Convert the left edge of the camera's viewport to world space
        Vector3 leftViewportEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
        leftBoundary = leftViewportEdge.x - 0.5f;
    }


    public void EndGame()
    {
        //Set the gameOver flag to prevent multiple triggers
        gameOver = true;

        //Load end game scene
        SceneManager.LoadScene("EndGameScene");
    }

    //Collision detection with enemies
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the collided object has the tag "enemy" and game over flag is not set
        if (collision.gameObject.CompareTag("enemy") && !gameOver)
        {
            //Trigger end game screen
            EndGame();
        }
    }
}

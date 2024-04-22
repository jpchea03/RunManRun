//This script gives the menu item buttons functionality.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Plays the first scene
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //Plays the first scene using scene manager
    }

    //Quits the game
    public void QuitGame()
    {
        Debug.Log("Exiting game..."); //Log message for unity editor
        Application.Quit(); //Will exit application if built.
    }
}

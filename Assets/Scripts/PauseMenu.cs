//Controls the pause menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    void Start()
    {
        // Closes pauseMenu on game start
        ClosePauseMenu();
    }

    //Closes pause menu
    public void ClosePauseMenu()
    {
        // Deactivate the pause menu UI
        pauseMenu.SetActive(false);
    }

    //Changes scene to main menu
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

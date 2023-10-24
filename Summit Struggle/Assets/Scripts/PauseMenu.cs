using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuCanvas;

    private void Update()
    {
        // Check for the "Escape" key to toggle between pause and resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1.0f; // Set the time scale back to normal to unpause the game
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0; // Set the time scale to 0 to pause the game
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..");
//<<<<<<< HEAD
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
//=======
        SceneManager.LoadSceneAsync(0);

        // Application.Quit();
//>>>>>>> main
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Called when we click the "Play" button.
    public void OnPlayButton ()
    {
        SceneManager.LoadSceneAsync(1);
    }
    // Called when we click the "Quit" button.
    public void OnQuitButton ()
    {
        Application.Quit();
    }
}
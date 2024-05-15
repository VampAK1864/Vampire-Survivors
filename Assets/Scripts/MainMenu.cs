using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevelName; // The first level name. GK

    public void StartGame() // Start the game. GK
    {
        SceneManager.LoadScene(firstLevelName); // Load the first level. GK
    }

    public void QuitGame() // Quit the game. GK
    {
        Application.Quit(); // Quit the game. GK
        Debug.Log("I'm Quitting");
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()          // function related to Main Menu "Start Game" button
    {
        SceneManager.LoadScene(1); 
                                    // will load scene which is next to the current scene in Build Settings
    }

    public void Options()          // function related to Main Menu "Start Game" button
    {
        SceneManager.LoadScene(2);
        // will load scene which is next to the current scene in Build Settings
    }



    public void QuitGame()          // Quit game function
    {
        Application.Quit();         // will close the application
    }
}
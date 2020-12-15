using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public void Restart()           
    {
        //SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadScene("SampleScene");  // will load SampleScene (which is 1st and only level in our game)
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        //SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadScene("SampleScene");  // will load SampleScene (which is 1st and only level in our game)  
                                                     // in future here will be reference to the next level
        Time.timeScale = 1;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);              // Will load Main Menu (scene with build No of 1 in Build Settings)
        Time.timeScale = 1;

    }
}

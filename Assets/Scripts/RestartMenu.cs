using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("SampleScene");      
        // right now only 1 Level, so this button directs back to level 1 again
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

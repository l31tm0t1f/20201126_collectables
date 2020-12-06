using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenuScript : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}

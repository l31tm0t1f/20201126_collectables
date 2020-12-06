using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenuScript : MonoBehaviour
{
    public GameObject ThePanel_Win;
    public GameObject ThePanel_Lost;


    void Start()
    {
        ThePanel_Win.SetActive(false);
        ThePanel_Lost.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

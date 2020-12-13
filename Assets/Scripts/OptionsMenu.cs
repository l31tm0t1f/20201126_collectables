using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("ParamVolume", volume);

    }

    public void BackToMain()          // function related to Main Menu "Start Game" button
    {
        SceneManager.LoadScene("Main Menu");
        // will load scene which is next to the current scene in Build Settings
    }
}

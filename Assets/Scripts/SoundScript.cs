using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Play sound globally
    private static SoundScript instance = null;
    
    public static SoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject); // object target will not be destroyed when loading new scene
    }
    // Play Global End

    // Update is called once per frame
    void Update()
    {
        
    }
}

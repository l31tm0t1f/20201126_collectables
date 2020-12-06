using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int SummaScore;            // int parameter also used in Spawner script
    public Text score;                       // Score as text

    void Start()                             // Start is called before the first frame update
    {
        score = GetComponent<Text>();        // variable "score" will be attributed with the Text component 
        SummaScore = 0;                      // SummaScore is 0 in the beginning
    }

    void Update()                            // Update is called once per frame
    {
        score.text = SummaScore.ToString();  // Text field will be attributed with SummaScore value which have been converted from int to string
    }
}

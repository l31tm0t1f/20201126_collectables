﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour

{
    public static int SummaScore;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        SummaScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = SummaScore.ToString();
    }
}

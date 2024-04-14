using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public string levelname;
    public float score;

    public Score(string levelname, float score)
    {
        this.levelname = levelname;
        this.score = score;
    }
}

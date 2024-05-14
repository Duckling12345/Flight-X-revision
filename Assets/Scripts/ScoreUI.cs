using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Properties;
//using UnityEditor.SceneTemplate;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    int totalQuestions = 5;

    void Start()
    {
       DisplayScore("Quiz");
    }

    void DisplayScore(string quizLvl)
    {
        int htpscore = PlayerPrefs.GetInt("htpScore", 0);
        int lopscore = PlayerPrefs.GetInt("lopScore", 0);
        int fobscore = PlayerPrefs.GetInt("fobScore", 0);
        int wlscore =  PlayerPrefs.GetInt("wlScore", 0);

        //Rows
        var row1 = Instantiate(rowUi, transform).GetComponent<RowUI>();
        row1.rank.text = "1";
        row1.levelname.text = "Pre-Flight Checking"; 
        row1.score.text = htpscore.ToString() + "/" + totalQuestions;

        var row2 = Instantiate(rowUi, transform).GetComponent<RowUI>();
        row2.rank.text = "2";
        row2.levelname.text = "Loss of Pressurization";
        row2.score.text = lopscore.ToString() + "/" + totalQuestions;

        var row3 = Instantiate(rowUi, transform).GetComponent<RowUI>();
        row3.rank.text = "3";
        row3.levelname.text = "Fire Onboard";
        row3.score.text = fobscore.ToString() + "/" + totalQuestions;

        var row4 = Instantiate(rowUi, transform).GetComponent<RowUI>();
        row4.rank.text = "4";
        row4.levelname.text = "Water Landing";
        row4.score.text = wlscore.ToString() + "/" + totalQuestions;
    }
}

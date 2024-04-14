using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Properties;
using UnityEditor.SceneTemplate;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    //public ScoreManager scoreManager;
    public int totalQuizzes = 4;

    void OnEnable()
    {
        for (int i = 1; i <= totalQuizzes; i++)
        {
            DisplayScore("Quiz" + i); 
        }
    }

    void DisplayScore(string quizLvl)
    {
        int score = PlayerPrefs.GetInt(quizLvl + "Score", 0);

        string quizNumber = quizLvl.Substring("Quiz".Length);

        var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
        row.rank.text = quizNumber;
        row.levelname.text = "Quiz Name"; 
        row.score.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public int number;

    public Slider slider;
    public GameObject Quizpanel;
    public GameObject  GoPanel;    
    public TMP_Text QuestionTxt;
    public Text ScoreTxt;
    public TMP_Text QuestionNum;

    int totalQuestions = 0;
    public int score;
    public int sceneBuildIndex;

    public void Start()
    {
        number = 1;
        totalQuestions = QnA.Count;
        QuestionNum.text = "Question " + number.ToString() + "/" + totalQuestions;
        GoPanel.SetActive(false);
        generateQuestions();
        Debug.Log("Current number:" + number);
    }

    public void GameOver() {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        slider.value = score;
        ScoreTxt.text =  score + "/" + totalQuestions;
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
        Debug.Log("Current Score" + score);
    }
    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    IEnumerator WaitForNext()
    {
        number++;
        yield return new WaitForSeconds(1);
        generateQuestions();
        QuestionNum.text = "Question " + number.ToString() + "/" + totalQuestions;
        Debug.Log(currentQuestion);
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void proceed()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    void SetAnswers()
    {

        for (int i = 0; i < options.Length; i++) {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;       
            }
        
        }
    }
    void generateQuestions()
    {
        if(QnA.Count > 0) {
            currentQuestion = Random.Range(0, QnA.Count);
         
            QuestionTxt.text = QnA[currentQuestion].Questions;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
            GameOver(); 
        }
       
    }

}

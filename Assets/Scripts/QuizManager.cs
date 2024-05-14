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
    public Image changeImage;
    public int currentQuestion;
    public int number;
    public Button proceedButton;

    public Slider testSlider;
    public Slider simSlider;
    public GameObject Quizpanel;
    public GameObject GoPanel;
    public GameObject TryAgainPanel;
    //public GameObject timer;
    //public GameObject stars;
    //public TMP_Text TimeLeftA;
    //public TMP_Text TimeLeftM;
    //public TMP_Text ObjDone;
    //public TMP_Text FireLeft;
   // public TMP_Text LifeVestGiven;
    public TMP_Text QuestionTxt;
    public Text ScoreTxt;
    public Text SimScoreTxt;
    public TMP_Text QuestionNum;

    int totalQuestions = 0;
    public int score;
    public int simScore;
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

    public void GameOver()
    {

        string activeSceneName = SceneManager.GetActiveScene().name;

        if (activeSceneName == "1_QuestionsScene (PFD)")
        {
            PlayerPrefs.SetInt("htpScore", score);
        }

        else if (activeSceneName == "2_QuestionsScene (LOP)")
        {
            PlayerPrefs.SetInt("lopScore", score);
        }

        else if (activeSceneName == "3_QuestionsScene (Fire)")
        {
            PlayerPrefs.SetInt("fobScore", score);
        }

        else if (activeSceneName == "4_QuestionsScene (Ditching)")
        {
            PlayerPrefs.SetInt("wlScore", score);
        }

        else
        {
            Debug.LogError("Unknown scene name: " + activeSceneName);
        }

        PlayerPrefs.Save();

        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        //  GetComponent<StarsHandler>().starsAchieved();
        //stars.SetActive(true);

        testSlider.value = score;
        simSlider.value = simScore;

        //percentage results
        float scorePercentage = ((float)score / (float)totalQuestions) * 100f;
        float simScorePercentage = ((float)simScore / (float)simScore) * 100f;
        ScoreTxt.text = Mathf.RoundToInt(scorePercentage) + "%";
        SimScoreTxt.text = Mathf.RoundToInt(simScorePercentage) + "%";

        //prev code
        //ScoreTxt.text =  score + "/" + totalQuestions;
        //SimScoreTxt.text = simScore + "/" + simScore;

        //convert to text
        //TimeLeftA.txt =
        //TimeLeftM.txt =
        //ObjDone.txt =
        //FireLeft.txt =
        //LifeVestGiven.txt =
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

    public void exit()
    {
        if (score >= 3)
        {
            proceedButton.interactable = true;
            SceneManager.LoadScene("Level Modules");
        }
        else
        {
            proceedButton.interactable = false;

            if (TryAgainPanel != null)
            {
                TryAgainPanel.SetActive(true);
            }
        }
    }

    public void proceed()
    {
        if (score >= 3)
        {
            proceedButton.interactable = true;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            UnlockNew();
        }
        else
        {
            proceedButton.interactable = false;

            if (TryAgainPanel != null)
            {
                TryAgainPanel.SetActive(true);
            }
        }
    }

    //Unlock Level
    void UnlockNew()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();

        }
    }
    void SetAnswers()
    {

        for (int i = 0; i < options.Length; i++)
        {
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
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            changeImage.sprite = QnA[currentQuestion].images;
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

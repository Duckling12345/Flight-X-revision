using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsHandler : MonoBehaviour
{
    public GameOverManager timer;
    public GameObject[] stars;
    public UnlockDoor SceneMover;
    public TMP_Text TimeLeft;

    public void starsAchieved()
    {
        if (timer.remainingTime >= 1f && timer.remainingTime <= 15f)
        {
            // One star
            stars[0].SetActive(true);
        }
        else if (timer.remainingTime >= 16f && timer.remainingTime <= 44f)
        {
            // Two stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else
        {
            // Three stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }

        // Remaining time 
        int seconds = Mathf.FloorToInt(timer.remainingTime);
        TimeLeft.text = "Time Left: " + seconds.ToString() + " seconds";
    }

    public void Quiz()
    {
        SceneMover.NextLevel();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Level Modules");
    }
}

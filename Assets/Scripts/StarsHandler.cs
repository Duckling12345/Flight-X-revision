using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class StarsHandler : MonoBehaviour
{
    public GameOverManager timer;
    public GameObject[] stars;
    public UnlockDoor SceneMover;
    public TMP_Text TimeLeft;
    public int seconds;
    public WrongScript wrongButton1;
    public WrongScript wrongButtton2;
    public int starsActive;
    public int checkActive;
     
    public void starsAchieved()
    {
        if (timer.remainingTime >= 1f && timer.remainingTime <= 15f || wrongButton1.buttonPressed && wrongButton1.objectiveID == 1)
        {
            // One star
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            starsActive = 1;
        }
        else if (timer.remainingTime >= 16f && timer.remainingTime <= 44f || wrongButton1.buttonPressed && wrongButton1.objectiveID == 2)
        {
            // Two stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(false);
            starsActive = 2;
        }
        else if (timer.remainingTime >= 45f)
        {
            // Three stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            starsActive = 3;
        }

        else
        {
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            starsActive = 0;
        }

        // Remaining time   
        seconds = Mathf.FloorToInt(timer.remainingTime);
        checkActive = starsActive;
        Debug.Log(checkActive);
        TimeLeft.text = "Time Left: " + seconds.ToString() + " seconds";
        SaveData();
    }

    public void SaveData()
    {
       
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (activeSceneIndex == 14 )
        {
            PlayerPrefs.SetInt("lopTime", seconds);
            PlayerPrefs.SetInt("lopStar", checkActive);
        }

        else if (activeSceneIndex == 15)
        {
            PlayerPrefs.SetInt("lopMiniTime", seconds);
        }

        else if (activeSceneIndex == 20)
        {
            PlayerPrefs.SetInt("fobTime", seconds);
            PlayerPrefs.SetInt("fobStar", checkActive);
        }

        else if (activeSceneIndex == 21)
        {
            PlayerPrefs.SetInt("fobMiniTime", seconds);
        }
        else if (activeSceneIndex == 26)
        {
            PlayerPrefs.SetInt("waterTime", seconds);
            PlayerPrefs.SetInt("waterStar", checkActive);
        }
        else if (activeSceneIndex == 27)
        {
            PlayerPrefs.SetInt("waterMiniTime", seconds);
        }
        else
        {
            Debug.LogError("Unknown scene index: " + activeSceneIndex);
        }

        PlayerPrefs.Save();
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

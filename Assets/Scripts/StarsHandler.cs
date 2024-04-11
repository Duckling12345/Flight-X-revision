using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsHandler : MonoBehaviour
{
    public GameOverManager timer; 
    public GameObject[] stars;
    public UnlockDoor SceneMover;
    
    public void starsAchieved()
    {

        if (timer.remainingTime >= 1f && timer.remainingTime <= 15f) 
        {
            //one star
            stars[0].SetActive(true);
        }
        else if (timer.remainingTime >= 16f && timer.remainingTime <= 44f)
        {
            //two stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else
        {
            //three stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
    public void Quiz()
    {
        Time.timeScale = 1f;
        SceneMover.NextLevel();
    }

    public void backToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level Modules");

    }
}


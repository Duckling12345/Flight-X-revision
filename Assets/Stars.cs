using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public GameObject[] stars;
    public GameOverManager timer;

    private void Update()
    {
        starsAchieved();
    }



    public void starsAchieved()
    {
        if (timer.remainingTime >= 1f && timer.remainingTime <= 15f)
        {
            // One star
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
        }
        else if (timer.remainingTime >= 16f && timer.remainingTime <= 44f)
        {
            // Two stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(false);
        }
        else
        {
            // Three stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
}

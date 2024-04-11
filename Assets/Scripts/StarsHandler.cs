using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHandler : MonoBehaviour
{
    public GameObject[] stars;
    private int objCount;

    private void Start()
    {
        objCount = GameObject.FindGameObjectsWithTag("Objective").Length;
    }

    public void starsAchieved()
    {
        int objsLeft = GameObject.FindGameObjectsWithTag("Objective").Length;
        int objsCompleted = objCount - objsLeft;

        float percentage = float.Parse(objsCompleted.ToString()) / float.Parse(objCount.ToString()) * 100f;

        if (percentage >= 33f && percentage < 66)
        {
            //one star
            stars[0].SetActive(true);
        }
        else if (percentage >= 666 && percentage < 70)
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
}


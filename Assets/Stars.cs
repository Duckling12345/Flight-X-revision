using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public GameObject[] stars;
    public GameOverManager timer;
    public AudioSource soundSource;
    public AudioClip errorClip;

 
    private void Update()
    {
        StarsAchieved();
    }

    public void StarsAchieved()
    {
        if (timer.remainingTime >= 1f && timer.remainingTime <= 15f)
        {
            // One star
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            //soundSource.PlayOneShot(errorClip);
            //Invoke("MuteAudio", 1f);
        }
        else if (timer.remainingTime >= 16f && timer.remainingTime <= 44f)
        {
            // Two stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(false);
            //Invoke("MuteAudio", 1f);
        }
        else if (timer.remainingTime >= 45f)
        {
            // Three stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else
        {
            // No stars
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
        }
    }

    void MuteAudio()
    {
        soundSource.Stop();
    }

}

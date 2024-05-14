using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    public Stars stars;


    private void OnDisable()
    {
        PlayErrorSound();
        Debug.Log("object destroyed");
    }

    private void OnDestroy()
    {
        PlayErrorSound();
        Debug.Log("object destroyed");
    }

    void PlayErrorSound()
    {
        stars.soundSource.PlayOneShot(stars.errorClip);
    }
}

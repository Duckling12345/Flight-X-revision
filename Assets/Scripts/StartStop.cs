using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartStop : MonoBehaviour
{
    private VideoPlayer player;
    public Button button;
    public GameObject DisclaimerUI;
    public int buildIndex;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
    }


    private void Update()
    {
        
    }

    public void StartPlay()
    {
        if (player.isPlaying == false)
        {
            player.Play();
            DisclaimerUI.SetActive(false);
            player.loopPointReached += CheckOver;
        }
        else
        {
            player.Pause();
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(buildIndex); ;//the scene that you want to load after the video has ended.
    }
}

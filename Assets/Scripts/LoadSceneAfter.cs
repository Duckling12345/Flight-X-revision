using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadSceneAfter : MonoBehaviour
{

    private VideoPlayer player;


    private void Awake() 
    {
        player = GetComponent<VideoPlayer>();
    
        player.Play();
        player.loopPointReached += CheckOver; 
      
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

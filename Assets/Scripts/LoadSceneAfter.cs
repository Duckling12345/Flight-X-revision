using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadSceneAfter : MonoBehaviour
{

    private VideoPlayer player;
    public int buildIndex;
    public UnlockDoor sceneMove;


    private void Awake() 
    {
        player = GetComponent<VideoPlayer>();
    
        player.Play();
        player.loopPointReached += CheckOver; 
      
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        sceneMove.NextLevel();
    }
}

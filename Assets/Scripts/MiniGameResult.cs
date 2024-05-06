using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameResult : MonoBehaviour
{
    public GameOverManager timer;
    public UnlockDoor SceneMover;
    public TMP_Text TimeLeft;

    public void MiniGameComplete()
    {
        int seconds = Mathf.FloorToInt(timer.remainingTime);
        TimeLeft.text = "Time Left: " + seconds.ToString() + " seconds";
    }
    
}

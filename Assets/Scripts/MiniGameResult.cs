using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameResult : MonoBehaviour
{
    public ObjectiveScript ObjectiveScript;
    public GameOverManager timer;
    public UnlockDoor SceneMover;
    public TMP_Text TimeLeft;
    public TMP_Text FireLeft;
    public TMP_Text Rewards;

    public void Update()
    {
        MiniGameComplete(); 
    }
    public void MiniGameComplete()
    {
        int seconds = Mathf.FloorToInt(timer.remainingTime);
        int objCount = Mathf.FloorToInt(ObjectiveScript.objectivesDone);
        TimeLeft.text = seconds.ToString() + " seconds";
        FireLeft.text = objCount.ToString() + " done";
    }
    
}

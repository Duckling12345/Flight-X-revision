using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameResult_LOP : MonoBehaviour
{
    public StarsHandler takeTime;
    public GameOverManager timer;
    public GameObject disableTimer;
    public UnlockDoor SceneMover;
    public TMP_Text TimeLeft;
    public TMP_Text ObjDone;
    public int seconds;

    public void MiniGameComplete()
    {
        seconds = Mathf.FloorToInt(timer.remainingTime);
        int obj = 2;

        TimeLeft.text = seconds.ToString() + " seconds";
        ObjDone.text = obj.ToString() + " finished";
        disableTimer.SetActive(false);
        PlayerPrefs.SetInt("lopMiniTime", seconds);
        PlayerPrefs.Save();
    }

    public void Proceed()
    {
        SceneMover.NextLevel();
    }
}

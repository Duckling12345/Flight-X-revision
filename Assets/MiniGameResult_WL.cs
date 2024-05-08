using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameResult_WL : MonoBehaviour
{
    public GameOverManager timer;
    public UnlockDoor SceneMover;
    public TMP_Text TimeLeft;
    public TMP_Text LifeVestGiven;

    public void Update()
    {
        MiniGameComplete();
    }
    public void MiniGameComplete()
    {
        int seconds = Mathf.FloorToInt(timer.remainingTime);
        int obj = 6;

        TimeLeft.text = seconds.ToString() + " seconds";
        LifeVestGiven.text = obj.ToString() + " given";
    }

    public void Proceed()
    {
        SceneMover.NextLevel();
    }
}

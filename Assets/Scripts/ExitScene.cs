using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScene : MonoBehaviour
{
    public GameObject disableButton;
    public UnlockDoor nextScene;
    public GameObject disableTimer;
    public GameObject levelResult;
    public GameObject playerUI;

    void LevelResult()
    {
        levelResult.SetActive(true);
        playerUI.SetActive(false);
        GetComponent<StarsHandler>().starsAchieved();
        Time.timeScale = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        disableButton.SetActive(false);
        disableTimer.SetActive(false);
        LevelResult();
    }
}
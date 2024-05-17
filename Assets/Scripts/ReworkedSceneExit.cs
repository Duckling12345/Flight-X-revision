using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReworkedSceneExit : MonoBehaviour
{
    public GameObject disableButton;
    public UnlockDoor nextScene;
    public GameObject disableTimer;
    public GameObject levelResult;
    public GameObject playerUI;
    public GameObject timer;
    public GameObject stars;
    public UnityEngine.UI.Slider simSlider;
    public Text SimScoreTxt;
    public int simScore;

    void LevelResult()
    {
        levelResult.SetActive(true);
        playerUI.SetActive(false);
        timer.SetActive(false);
        stars.SetActive(false);

        simSlider.value = simScore;

        //percentage results
        float simScorePercentage = ((float)simScore / (float)simScore) * 100f;
        SimScoreTxt.text = Mathf.RoundToInt(simScorePercentage) + "%";
    }
    private void OnTriggerEnter(Collider other)
    {
        disableButton.SetActive(false);
        disableTimer.SetActive(false);
        LevelResult();
    }
}
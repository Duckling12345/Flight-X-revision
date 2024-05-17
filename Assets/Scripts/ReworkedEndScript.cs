using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ReworkedEndScript : MonoBehaviour
{
    public FireScript fireScript;
    public UnlockDoor sceneMover;
    public ParticleSystem partikol;
    [SerializeField] AudioSource audioSource;
    public GameObject levelResult;
    public GameObject playerUI;
    public GameObject timer;
    public GameObject stars;
    public UnityEngine.UI.Slider simSlider;
    public Text SimScoreTxt;
    public int simScore;

    // Update is called once per frame
    void Update()
    {
        Invoke("FadetoBlack", 5f);
    }
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
    private void FadetoBlack()
    {
        int numbers = partikol.particleCount;
        if (fireScript.isLit == false && numbers == 0)
        {
            timer.SetActive(false);
            audioSource.Stop();
            LevelResult();
        }
    }

}

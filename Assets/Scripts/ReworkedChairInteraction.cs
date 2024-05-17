using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ReworkedChairInteraction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public FixedSitButton fixedSitbutton;
    public Camera mainCamera;
    public Camera sittingCamera;
    public GameObject player; // The player GameObject
    public GameObject sittingPlayer; // The sitting player GameObject
    public GameObject mask;
    public Shake shaker;
    private Vector3 lastPlayerPosition; // Store the last position of the player before sitting

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] Animator wear;

    public UnlockDoor sceneMover;
    public GameObject EndSound;
    public GameObject deactivateCurrent;
    public GameObject removeButton;
    public GameObject levelResult;
    public GameObject playerUI;
    public GameObject timer;
    public GameObject stars;
    public Slider simSlider;
    public Text SimScoreTxt;
    public int simScore;

    public bool Pressed;
    public int timeToWait;


    private void Update()
    {
        if (fixedSitbutton.Pressed)
        {
            Sit();
            shaker.ShakeScreen();
            Invoke("playSound", 2f);
            Invoke("playAnimation", timeToWait);
            Invoke("playOxygen", 1f);
            deactivateCurrent.SetActive(false);
        }
    }


    public void Sit()
    {
        // Store the current position of the player before sitting
        lastPlayerPosition = player.transform.position;

        // Deactivate the main camera and activate the sitting camera
        mainCamera.gameObject.SetActive(false);
        sittingCamera.gameObject.SetActive(true);

        // Activate the sitting player and deactivate the standing player
        sittingPlayer.SetActive(true);
        player.SetActive(false);
        mask.SetActive(true);
        removeButton.SetActive(false);
        timer.SetActive(false);

    }

    public void playAnimation()
    {
        LevelResult();
    }

    public void playSound()
    {
        EndSound.SetActive(true);
    }


    public void playOxygen()
    {
        source.PlayOneShot(clip);
    }


    void LevelResult()
    {
        levelResult.SetActive(true);
        playerUI.SetActive(false);
        timer.SetActive(false);

        simSlider.value = simScore;
        //percentage results
        float simScorePercentage = ((float)simScore / (float)simScore) * 100f;
        SimScoreTxt.text = Mathf.RoundToInt(simScorePercentage) + "%";
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }


}

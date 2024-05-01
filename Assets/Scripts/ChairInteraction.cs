using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChairInteraction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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

    public bool Pressed;



    private void Update()
    {
        if (fixedSitbutton.Pressed)
        {
            Sit();
            shaker.ShakeScreen();
            Invoke("playSound", 2f);
            Invoke("playAnimation", 15f);
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
        GetComponent<StarsHandler>().starsAchieved();
        timer.SetActive(false);    
        stars.SetActive(false);
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

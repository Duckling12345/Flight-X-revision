using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChairInteraction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public FixedSitButton fixedSitbutton;
    public Camera mainCamera;
    public Camera sittingCamera;
     public  bool Pressed;
    public GameObject player; // The player GameObject
    public GameObject sittingPlayer; // The sitting player GameObject
    public Shake shaker;
    private Vector3 lastPlayerPosition; // Store the last position of the player before sitting
    public GameObject mask;
    [SerializeField] Animator wear;
    public UnlockDoor sceneMover;
    public GameObject EndSound;
    public GameObject deactivateCurrent;
    public GameObject removeButton;

    private void Update()
    {
        if (fixedSitbutton.Pressed)
        {
            Sit();
            shaker.ShakeScreen();
            Invoke("playSound", 2f);
            Invoke("playAnimation", 15f);
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
        wear.Play("WearOxygen");
        AudioManager.Instance.PlayOxygenSound();
        removeButton.SetActive(false);

    }

    public void playAnimation()
    {
        sceneMover.NextLevel();
    }

    public void playSound()
    {
        EndSound.SetActive(true);
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

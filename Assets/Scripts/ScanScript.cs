using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScanScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject objectiveText3;
    public GameObject scanButton;
    public GameObject goBackButton; // Button to stand up
    public GameObject door; 
    public GameObject defaultObject;
    public GameObject Activate;
    public FixedBackButton fixedBackbutton;
    public FixedScanButton fixedscanbutton;

    public Camera mainCamera;
    public Camera scanCamera;
    public bool Pressed;
    public GameObject player; // The player GameObject
    public GameObject lookCapsule; // The sitting player GameObject
    private Vector3 lastPlayerPosition; // Store the last position of the player before sitting

    public TMP_Text objectiveText1;
    public TMP_Text objectiveText2;
    public ObjectiveScript objective;
    public int objectiveID;
    public string statetoPlay;

    [SerializeField] Animator openDoor;
    [SerializeField] Animator popupAnimator;

    public GameObject ActivateIndicator;
    public GameObject DeactivateIndicator;

    private void Update()
    {
        if (fixedscanbutton.Pressed && objective.objectivesDone == objectiveID)
        {
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            Sit();
        }
        else if (fixedBackbutton.Pressed && objective.objectivesDone == objectiveID)
        {
            objectiveText2.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            Stand();
        }
    }


    public void Sit()
    {
        // Store the current position of the player before sitting
        lastPlayerPosition = player.transform.position;

        // Deactivate the main camera and activate the sitting camera
        mainCamera.gameObject.SetActive(false);
        scanCamera.gameObject.SetActive(true);

        // Activate the sitting player and deactivate the standing player
        lookCapsule.SetActive(true);
        player.SetActive(false);

        // Activate the stand button
        goBackButton.SetActive(true);
        DeactivateIndicator.SetActive(false);

    }

    public void Stand()
    {
        // Deactivate the sitting camera and activate the main camera
        scanCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);

        // Deactivate the sitting player and activate the standing player
        lookCapsule.SetActive(false);
        player.SetActive(true);

        // Move the player back to the last position before sitting
        player.transform.position = lastPlayerPosition;

        // Disable the stand button

        Activate.SetActive(true);
        defaultObject.SetActive(false);
        goBackButton.SetActive(false);
        objectiveText3.SetActive(true);
        scanButton.SetActive(false);
        ActivateIndicator.SetActive(true);
        Invoke("PlayAnimationLate", 1f);
        AudioManager.Instance.PlayDoorSound();
    }


    void PlayAnimationLate()
    {
        openDoor.Play(statetoPlay);
        popupAnimator.Play("PopUpAnimation");
    }


    private void OnTriggerExit(Collider other)
    {
        lookCapsule.SetActive(false);
        player.SetActive(true);
        scanButton.SetActive(false);

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

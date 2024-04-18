using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObj : MonoBehaviour, IInteractable
{
    public GameObject activate;
    public GameObject deactivate;
    public GameObject activateNext;
    public GameObject deactivateCurrent;
    public FixedButton fixbutton;
    public ObjectiveScript objectives;
    public int objectivesID;
    [SerializeField] Animator cameraAnimation;
    [SerializeField] Animator pouchAnimation;
    public string cameraStateName;
    public string pouchStateName;
    public GameObject DestroyOnExit;
    public GameObject InteractButton;


    private void Update()
    {
        if(fixbutton.Pressed == true && objectives.objectivesDone == objectivesID) 
        { 
            Interact();
            Invoke("destroyObjects", 4f);
        }
    }
    public void Interact()
    {
        activate.SetActive(true);
        AudioManager.Instance.PlayInspectSound();
        activateNext.SetActive(true);
        deactivateCurrent.SetActive(false);
        deactivate.SetActive(false);
        cameraAnimation.Play(cameraStateName);
        Invoke("delayAnimation", 1f);
    }

    public void delayAnimation()
    {
        pouchAnimation.Play(pouchStateName);

    }

    public void destroyObjects()
    {
        DestroyOnExit.GetComponent<BoxCollider>().enabled = false;
        activate.SetActive(false);
        deactivate.SetActive(true);
        InteractButton.SetActive(false);
    }


    private void OnTriggerExit(Collider other)
    {
        activate.SetActive(false);
        deactivate.SetActive(true);
        InteractButton.SetActive(false);
    }
}

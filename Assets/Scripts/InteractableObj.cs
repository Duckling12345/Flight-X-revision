using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObj : MonoBehaviour, IInteractable
{
    [SerializeField] Animator transitionAnim;
    public GameObject activate;
    public GameObject activateNext;
    public GameObject deactivateCurrent;
    public FixedButton fixbutton;
    public ObjectiveScript objectives;
    public int objectivesID;

    private void Update()
    {
        if(fixbutton.Pressed == true && objectives.objectivesDone == objectivesID) 
        { 
            Interact();
        }
    }
    public void Interact()
    {
        activate.SetActive(true);
        transitionAnim.Play("FadeIn");
        AudioManager.Instance.PlayInspectSound();
        activateNext.SetActive(true);
        deactivateCurrent.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        activate.SetActive(false);
    }
}

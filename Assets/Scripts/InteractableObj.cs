using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObj : MonoBehaviour, IInteractable
{
    public GameObject defaultChair;
    public GameObject hideDefaultChair;
    public GameObject activate;
    public GameObject deactivate;
    public GameObject activateNext;
    public GameObject deactivateCurrent;
    public FixedButton fixbutton;
    public ObjectiveScript objectives;
    public int objectivesID;
    public TMP_Text inspectObjectiveText;
    public string inspectObjective;
    [SerializeField] Animator cameraAnimation;
    [SerializeField] Animator pouchAnimation;
    [SerializeField] Animator handsAnimation;
    public string cameraStateName;
    public string pouchStateName;
    public string handsStateName;
    public GameObject DestroyOnExit;
    public GameObject InteractButton;
    public GrayOutBullet grayout;


    private void Update()
    {
        if(fixbutton.Pressed == true && objectives.objectivesDone == objectivesID) 
        { 
            Interact();
            Invoke("destroyObjects", 4f);
            inspectObjectiveText.text = inspectObjective;
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
        handsAnimation.Play(handsStateName);

    }

    public void destroyObjects()
    {
        DestroyOnExit.GetComponent<BoxCollider>().enabled = false;
        activate.SetActive(false);
        deactivate.SetActive(true);
        InteractButton.SetActive(false);
        defaultChair.SetActive(true);
        hideDefaultChair.SetActive(false);
        grayout.GrayOutImage();
    }


    private void OnTriggerExit(Collider other)
    {
        InteractButton.SetActive(false); 
    }
}

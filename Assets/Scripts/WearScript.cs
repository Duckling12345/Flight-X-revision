using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WearScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   
    public GameObject ObjectToWear;
    public GameObject PBEWorn;
    public bool wearPressed;
    public TMP_Text objectiveText1;
    public FixedWearButton fixbutton;
    public GameObject disableButton;
    public ObjectiveScript objective;
    public int objectiveID;
    public GameObject activate;
    public GameObject activateNext;
    public GameObject deactivateCurrent;
    [SerializeField] Animator popupAnimator;
    public float timetowait;
    public GameObject fireExtinguisher;

    private void Update()
    {
        if (fixbutton.Pressed == true && objective.objectivesDone == objectiveID)
        {
            WearPBE();
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            Invoke("WaitAnimation", timetowait);
            fireExtinguisher.GetComponent<BoxCollider>().enabled = true;
        }
    }
    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");

    }
    void WearPBE()
    {
        if (wearPressed)
        {
           ObjectToWear.SetActive(false);
            disableButton.SetActive(false);
            PBEWorn.SetActive(true);
            activateNext.SetActive(true);
            deactivateCurrent.SetActive(false);
            AudioManager.Instance.PlayInspectSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(objective.objectivesDone == 2) { 
            objective.objectivesDone = -1;
        }
        disableButton.SetActive(false);
    }


    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        wearPressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        wearPressed = false;
    }
}

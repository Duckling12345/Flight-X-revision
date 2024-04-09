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
    [SerializeField] Animator transitionAnim;
    public GameObject activateNext;
    public GameObject deactivateCurrent;



    private void Update()
    {
        if (fixbutton.Pressed == true && objective.objectivesDone == objectiveID)
        {
            WearPBE();
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
        }
    }

    void WearPBE()
    {
        if (wearPressed)
        {
           ObjectToWear.SetActive(false);
            disableButton.SetActive(false);
            PBEWorn.SetActive(true);
            activate.SetActive(true);
            activateNext.SetActive(true);
            deactivateCurrent.SetActive(false);
            transitionAnim.Play("FadeIn");
            AudioManager.Instance.PlayInspectSound();
        }
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

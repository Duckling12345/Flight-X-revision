using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class VestScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public int objectiveID;
    public float timetowait;
    public bool wearPressed;

    [SerializeField] Animator popupAnimator;
    public GameObject ObjectToWear;
    public GameObject ExitStopper;
    
    public TMP_Text objectiveText1;
    public FixedInflateButton fixbutton;
    public GameObject disableButton;
    public ObjectiveScript objective;
    
    public GameObject activateEnd;
    public GameObject ActivateIndicator;
    public GameObject DeactiveIndicator;
    public GameObject WearVest;
    
    
   





    private void Update()
    {
        if (fixbutton.Pressed == true && objective.objectivesDone == objectiveID || wearPressed == true)
        {
            ObjectToWear.SetActive(false);
            disableButton.SetActive(false);
            ExitStopper.SetActive(false);
            activateEnd.SetActive(true);
            ActivateIndicator.SetActive(true);
            DeactiveIndicator.SetActive(false);
            WearVest.SetActive(true);
            AudioManager.Instance.PlayInspectSound();
            Invoke("WaitAnimation", timetowait);
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
        }
    }

    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");

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

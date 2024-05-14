using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LastPassenger : MonoBehaviour
{
    public TMP_Text objectiveText1;
    public FixedSeatbeltButton fixbutton;
    public ObjectiveScript objective;
    public int objectiveID;
    [SerializeField] Animator popupAnimator;
    public float timetowait;
    public GameObject oxygens;
    public GameObject seatbelt;
    [SerializeField] Animator BuckleAnim;
    public GameObject CameraAnimation;
    public string StateName;
    public GameObject tempDisable;
    public Shake shaker;
    public GameObject activateNext;
    public GameObject deactivateCurrent;
    public GameObject DestroyOnExit;
    public GameObject InteractButton;
    public TMP_Text fastenObjectiveText;
    public string fastenObjective;
    public GameObject defaultChair;
    public GameObject hideDefaultChair;
    public Image bullet;

    private void Update()
    {
        
        if (fixbutton.Pressed == true && objective.objectivesDone == objectiveID)
        {
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            bullet.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            Invoke("WaitAnimation", timetowait);
            oxygens.SetActive(true);
            seatbelt.SetActive(true);
            CameraAnimation.SetActive(true);
            BuckleAnim.Play(StateName);
            tempDisable.SetActive(false);
            activateNext.SetActive(true);
            deactivateCurrent.SetActive(false);
            AudioManager.Instance.PlayBuckleSound();
            Invoke("destroyObjects", 4f);
            fastenObjectiveText.text = fastenObjective;
        }
    }

    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");
    }


    public void destroyObjects()
    {
        DestroyOnExit.GetComponent<BoxCollider>().enabled = false;
        CameraAnimation.SetActive(false);
        tempDisable.SetActive(true);
        InteractButton.SetActive(false);
        defaultChair.SetActive(true);
        hideDefaultChair.SetActive(false);
    }


}

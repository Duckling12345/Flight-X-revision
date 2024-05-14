using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LastObjective : MonoBehaviour
{
    public GameObject missingObjective;
    public FixedButton fixbutton;
    public GameObject active;
    public GameObject inactive;
    public GameObject disableButton;
    public TMP_Text objectiveText1;
    public ObjectiveScript objective;
    public int objectiveID;
    public GameObject activateNext;
    public GameObject deactivateCurrent;
    public GameObject Stopper;
    [SerializeField] Animator popupAnimator;
    public Image bullet;
    private void Update()
    {
        if (fixbutton.Pressed == true && objective.objectivesDone == objectiveID)
        {
            missingObjective.SetActive(true);
            inactive.SetActive(false);
            active.SetActive(true);
            disableButton.SetActive(false);
            activateNext.SetActive(true);
            deactivateCurrent.SetActive(false);
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            bullet.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            Stopper.SetActive(false);
            Invoke("WaitAnimation", 1f);
        }
    }
    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");

    }

}

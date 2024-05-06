using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameFire_2 : MonoBehaviour
{
    public FixedExtinguishButton fixedExtinguish;
    public ObjectiveScript objective;
    public TMP_Text objectiveText1;
    public TMP_Text extObjectiveText;
    public string extObjective;
    public int objectiveID;
    [SerializeField] Animator popupAnimator;

    public GameObject removeButton;
    public GameObject levelResult;
    public GameObject playerUI;
    public GameObject timer;

    private void Update()
    {
        if (fixedExtinguish.buttonPressed == true && objective.objectivesDone == objectiveID)
        {
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            extObjectiveText.text = extObjective;
            Invoke("WaitAnimation", 1f);
            Invoke("playAnimation", 5f);
        }
    }
    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");

    }
    public void playAnimation()
    {
        MGResult();
    }

    void MGResult()
    {
        levelResult.SetActive(true);
        playerUI.SetActive(false);
        timer.SetActive(false);
    }
}

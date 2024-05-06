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
    public GameObject removeButton;
    public GameObject removeJoystick;
    public GameObject levelResult;
    public GameObject playerUI;
    public GameObject timer;
    public GameObject stopAnimation;
    [SerializeField] Animator popupAnimator;

    public FireScript fireScript;
    public ParticleSystem partikol;

    private void Update()
    {
        if (fixedExtinguish.buttonPressed == true && objective.objectivesDone == objectiveID)
        {
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            extObjectiveText.text = extObjective;
            Invoke("WaitAnimation", 1f);
            Invoke("playAnimation", 5f);
            FadetoBlack();
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
        removeJoystick.SetActive(false);
    }

    private void FadetoBlack()
    {
        int numbers = partikol.particleCount;
        if (fireScript.isLit == false && numbers == 0)
        {
            timer.SetActive(false);
            stopAnimation.SetActive(false);
        }
    }
}

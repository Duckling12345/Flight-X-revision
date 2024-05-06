using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameFire : MonoBehaviour
{
    public FixedExtinguishButton fixedExtinguish;
    public ObjectiveScript objective;
    public TMP_Text objectiveText1;
    public string extObjective;
    public int objectiveID;
    [SerializeField] Animator popupAnimator;

    private void Update()
    {
        if (fixedExtinguish.buttonPressed == true && objective.objectivesDone == objectiveID)
        {
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            Invoke("WaitAnimation", 1f);
        }
    }

    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");

    }
}

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
    public TMP_Text extObjectiveText;
    public int objectiveID;
    [SerializeField] Animator popupAnimator;

    private void Update()
    {
        if (fixedExtinguish.buttonPressed == true && objective.objectivesDone == objectiveID)
        {
            extObjectiveText.text = extObjective;
            Invoke("WaitAnimation", 1f);
        }
    }

    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");

    }
}

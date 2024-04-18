using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GrayOut : MonoBehaviour
{
    public TMP_Text objectiveText1;
    public FixedButton fixbutton;
    public ObjectiveScript objective;
    public int objectiveID;
    [SerializeField] Animator popupAnimator;
    public float timetowait;


    private void Update()
    {
       if (fixbutton.Pressed == true && objective.objectivesDone == objectiveID)
        {
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            Invoke("WaitAnimation", timetowait);
        }
    }

    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");
    }

}

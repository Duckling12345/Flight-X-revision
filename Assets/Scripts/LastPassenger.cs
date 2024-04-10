using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private void Update()
    {
        
        if (fixbutton.Pressed == true && objective.objectivesDone == objectiveID)
        {
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            Invoke("WaitAnimation", timetowait);
            oxygens.SetActive(true);
            seatbelt.SetActive(true);
        }
    }

    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameFire : MonoBehaviour
{
    public FixedButton fixbutton;
    public GameObject active;
    public GameObject inactive;
    public GameObject disableButton;
    public TMP_Text objectiveText1;
    public ObjectiveScript objective;
    public int objectiveID;
    [SerializeField] Animator popupAnimator;

    private void Update()
    {
        if (fixbutton.Pressed == true && objective.objectivesDone == objectiveID)
        {
            inactive.SetActive(false);
            active.SetActive(true);
            disableButton.SetActive(false);
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
            Invoke("WaitAnimation", 1f);
        }
    }

    public void WaitAnimation()
    {
        popupAnimator.Play("PopUpAnimation");

    }
}

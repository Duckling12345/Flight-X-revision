using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            Stopper.SetActive(false);

        }
    }



}

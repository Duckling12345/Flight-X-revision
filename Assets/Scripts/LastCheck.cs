using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;
//using UnityEngine.WSA;

public class LastCheck : MonoBehaviour
{
    public TMP_Text objectiveText;
    public TMP_Text objectiveText1;
    public GameObject disableObjectiveText;
    public GameObject disableObjectiveText2;
    public ObjectiveScript objective;
    public int objectiveID;

    public string changeObjectiveText;
    public string changeObjectiveText1;
    public GameObject DisableButton;

    public GameObject ActivateIndicator;
    public GameObject DeactiveIndicator;
    public GameObject removeNPC;
    
    private void OnTriggerEnter(Collider other)
    {

        if (objective.objectivesDone == objectiveID)
        {
            DisableButton.SetActive(false);
            objectiveText.text = changeObjectiveText;
            objectiveText.color = Color.black;

            objectiveText1.text = changeObjectiveText1;
            objectiveText1.color = Color.black;


            disableObjectiveText.SetActive(false);
            disableObjectiveText2.SetActive(false);

            ActivateIndicator.SetActive(true);
            DeactiveIndicator.SetActive(false);

            removeNPC.SetActive(false);
        }
    }
}

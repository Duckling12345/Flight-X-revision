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


    private void Update()
    {
        if (fixbutton.Pressed == true && objective.objectivesDone == objectiveID)
        {
            objectiveText1.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
        }
    }
}

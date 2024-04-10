using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceCheck : MonoBehaviour
{
    [SerializeField]

    private string correctSequence, currentSequence;
    public UnlockDoor sceneMover;

    private void Start()
    {
        Buttons.SendColorValue += AddValueAndCheckSequence;
        correctSequence = "123";
        currentSequence = "";
    }


    private void AddValueAndCheckSequence(string buttonColor)
    {
        switch (buttonColor)
        {
            case "LifeVest":
                currentSequence += 1;
                break;
            case "Seatbelt": 
                currentSequence += 2; 
                break;
            case "Oxygen":
                currentSequence += 3;
                break;
        }

        if(currentSequence != correctSequence.Substring(0, currentSequence.Length))
        {
            currentSequence = "";
            Debug.Log("Incorrect");
        } else if (currentSequence == correctSequence)
        {
            currentSequence = "";
            Destroy(gameObject);
            sceneMover.NextLevel();
        }

    }

    private void OnDestroy()
    {
        Buttons.SendColorValue -= AddValueAndCheckSequence;

    }

}

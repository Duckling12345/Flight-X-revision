using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssessmentScript : MonoBehaviour
{
    public GameObject InteractButton;
    public int objectiveID;

    public static event Action<string> SendColorValue = delegate { };


    public void ButtonClicked()
    {
        SendColorValue(name.Substring(0, name.IndexOf("_")));
        Debug.Log("pressed and sent");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Entrered the collider");
            InteractButton.SetActive(true);   
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Exited");
        InteractButton.SetActive(false);
        //DestroyOnExit.GetComponent<BoxCollider>().enabled =false;
    }
}

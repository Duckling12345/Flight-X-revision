using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssessmentScript : MonoBehaviour
{
    public GameObject InteractButton;
    public int objectiveID;
  
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

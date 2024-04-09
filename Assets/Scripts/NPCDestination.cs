using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCDestination : MonoBehaviour
{
    public GameObject passenger1;
    public GameObject passenger4;

    private void OnTriggerExit(Collider other)
    {
        passenger1.SetActive(false);
        passenger4?.SetActive(false);   
    }

}
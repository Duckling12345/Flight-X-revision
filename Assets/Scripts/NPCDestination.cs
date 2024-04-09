using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCDestination : MonoBehaviour
{
    public GameObject passenger1;
    public GameObject passenger4;


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "NPC" || collision.gameObject.name == "Passenger")
        {
            Debug.Log("ay natrigger");
            passenger1.SetActive(false);
            passenger4.SetActive(false); 
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }

}
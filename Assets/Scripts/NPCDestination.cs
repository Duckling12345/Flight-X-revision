using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCDestination : MonoBehaviour
{
    public GameObject passenger1;
    public GameObject addedpassenger;
    public GameObject passenger4;
    public GameObject remove;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "NPC" || collision.gameObject.name == "Passenger")
        {
            Debug.Log("ay natrigger");
            passenger1.SetActive(false);
            addedpassenger.SetActive(false);
            passenger4.SetActive(false); 
            remove.SetActive(false);
           
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }

}
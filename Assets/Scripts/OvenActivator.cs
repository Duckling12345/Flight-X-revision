using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OvenActivator : MonoBehaviour
{
    public GameObject extinguishButton;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Player Entrered the collider");
            extinguishButton.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Exited");
        extinguishButton.SetActive(false);
    }

    private void OnDisable()
    {
        extinguishButton.SetActive(false);

    }

}

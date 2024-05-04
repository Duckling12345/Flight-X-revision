using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PassengerScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool Pressed;
    //public string stateName;
    public int objectiveID;
    public GameObject vestButton;
    public GameObject disableCurrentIndicator;
    //[SerializeField] Animator playerAnimation;
    


    void Start()
    {
        
    }

    void Update()
    {
           if(Pressed == true && objectiveID == 1)
        {
            disableCurrentIndicator.SetActive(false);
        }
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        vestButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        vestButton.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;

    }
}

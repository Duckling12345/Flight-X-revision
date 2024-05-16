using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WrongScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject button1;
    public Button wrongbutton;
    public GameObject panel;
    public bool buttonPressed;
    public StarsHandler starHand;
    public Stars stars2;
    public int objectiveID;




    private void OnTriggerEnter(Collider other)
    {
        button1.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        button1.SetActive(false);
    }

    public void RemoveInteract()
    {
        panel.SetActive(true);
        wrongbutton.interactable = false;
        //starHand.stars[objectiveID].SetActive(false);
       // stars2.stars[objectiveID].SetActive(false);
        buttonPressed = true;
    }

    private void OnDisable()
    {
        wrongbutton.interactable = true;
        button1.SetActive(false);
        panel.SetActive(false);

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }




}

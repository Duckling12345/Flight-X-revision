using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedExtinguishButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    //discontinued still waiting for updates so that we can proceed adding animawtion and removing gameobject "fire"    
    public bool buttonPressed;
    public void OnPointerDown(PointerEventData eventData)
    {

        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;

    }
}

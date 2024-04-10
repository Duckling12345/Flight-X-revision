using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool Pressed;

    public static event Action<string> SendColorValue = delegate {};


    public void ButtonClicked()
    {
        SendColorValue(name.Substring(0, name.IndexOf("_")));
        Debug.Log("pressed and sent");
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}





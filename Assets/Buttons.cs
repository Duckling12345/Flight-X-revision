using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool Pressed;
    public bool wearPressed;
    public bool seatbeltPressed;

    public FixedSeatbeltButton fixedSeatbeltButton;
    public FixedWearButton fixedWearButton;
    public FixedButton fixedButton;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ButtonCheck();     

    }

    void ButtonCheck()
    {
        

    }




    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        wearPressed = true;
        seatbeltPressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        wearPressed = false;
        seatbeltPressed = false;
    }
}

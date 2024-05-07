using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTouchController : MonoBehaviour
{
    public PassengerScript vestScript;
    public PassengerScript1 vestScript1;
    public PassengerScript2 vestScript2;
    public PassengerScript3 vestScript3;
    public PassengerScript4 vestScript4;
    public PassengerScript5 vestScript5;

    public FixedInflateButton fixedInflateButton;
    public FixedInflateButton1 fixedInflateButton1;
    public FixedInflateButton2 fixedInflateButton2;
    public FixedInflateButton3 fixedInflateButton3;
    public FixedInflateButton4 fixedInflateButton4;
    public FixedInflateButton5 fixedInflateButton5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vestScript.Pressed = fixedInflateButton.Pressed;
        vestScript1.Pressed = fixedInflateButton1.Pressed;
        vestScript2.Pressed = fixedInflateButton2.Pressed;
        vestScript3.Pressed = fixedInflateButton3.Pressed;
        vestScript4.Pressed = fixedInflateButton4.Pressed;
        vestScript5.Pressed = fixedInflateButton5.Pressed;

    }
}
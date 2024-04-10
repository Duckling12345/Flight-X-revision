using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTouchController : MonoBehaviour
{
    public FixedSeatbeltButton fixedSeatbeltButton;
    public FixedWearButton fixedWearButton;
    public FixedButton fixedButton;
    public Buttons button;
    public Buttons button2;
    public Buttons button3;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        button2.seatbeltPressed = fixedSeatbeltButton.Pressed;
        button3.Pressed = fixedButton.Pressed;
        button.wearPressed = fixedWearButton.Pressed;
    }
}

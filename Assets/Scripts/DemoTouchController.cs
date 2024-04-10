using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTouchController : MonoBehaviour
{
    public Buttons buttons;
    public FixedButton fixedButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttons.Pressed = fixedButton.Pressed;
    }
}

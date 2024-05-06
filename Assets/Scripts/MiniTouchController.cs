using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTouchController : MonoBehaviour
{
    public PassengerScript vestScript;
    public FixedInflateButton fixedInflateButton;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vestScript.Pressed = fixedInflateButton.Pressed;

    }
}
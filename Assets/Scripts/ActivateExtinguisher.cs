using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateExtinguisher : MonoBehaviour
{
    public FixedExtinguishButton fixedExtinguish;
    public ExtinguisherScript extinguisher;
    public FixedWearButton fixedWear;
    public WearScript wear;
    public MiniGamePBE wearr;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        extinguisher.Pressed = fixedExtinguish.buttonPressed;
        wearr.wearPressed = fixedWear.Pressed;
    }
}

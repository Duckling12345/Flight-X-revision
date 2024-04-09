using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateExtinguisher : MonoBehaviour
{
    public FixedExtinguishButton fixedExtinguish;
    public ExtinguisherScript extinguisher;
    public FixedWearButton fixedWear;
    public WearScript wear;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        extinguisher.Pressed = fixedExtinguish.buttonPressed;
        wear.wearPressed = fixedWear.Pressed;
    }
}

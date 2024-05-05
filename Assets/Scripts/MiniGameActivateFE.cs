using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameActivateFE : MonoBehaviour
{
    public FixedExtinguishButton fixedExtinguish;
    public ExtinguisherScript extinguisher;
    void Start()
    {
        
    }

    
    void Update()
    {
        extinguisher.Pressed = fixedExtinguish.buttonPressed;
    }
}

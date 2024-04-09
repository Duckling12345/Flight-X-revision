using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitchingTouchController : MonoBehaviour
{

    public VestScript vestScript;
    public FixedInflateButton fixedInflateButton;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vestScript.wearPressed = fixedInflateButton.Pressed;
        
    }
}

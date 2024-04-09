using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTouchController : MonoBehaviour
{
    public FixedBackButton fixedBackButton;
    public ScanScript scanScript;
    public FixedScanButton scanButton;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fixedBackButton.Pressed = scanScript.Pressed;
        scanButton.Pressed = scanScript.Pressed;
    }
}

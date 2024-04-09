using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelShake : MonoBehaviour
{
    public Shake shaker;
    public Shake shaker2;

    void Awake()
    {
            shaker.ShakeScreen();
            shaker2.ShakeScreen();
        
    }
}

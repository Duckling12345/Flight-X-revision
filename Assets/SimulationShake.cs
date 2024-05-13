using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationShake : MonoBehaviour
{
    public Shake shaker;

    private void Awake()
    {
        shaker.ShakeScreen();         
    }



}

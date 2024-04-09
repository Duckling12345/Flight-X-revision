using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelShake : MonoBehaviour
{
    public NPCScript npc;
    public Shake shaker;
    public Shake shaker2;

    void Update()
    {
        if(npc.talkPressed)
        {
            shaker.ShakeScreen();
            shaker2.ShakeScreen();
        }
    }
}

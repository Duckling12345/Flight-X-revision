using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerActivate : MonoBehaviour
{
    public NPCScript npc;
    public GameObject timer;
    public GameObject Level;
    private void Update()
    {
        if(npc.talkPressed)
        {   
            timer.SetActive(true);
            Level.SetActive(true);
        }
    }

}

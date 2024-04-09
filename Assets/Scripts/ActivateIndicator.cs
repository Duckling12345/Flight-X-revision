using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateIndicator : MonoBehaviour
{
    public GameObject Level;
    public NPCScript npc;
    public GameObject activateFirstObj;

    private void Update()
    {
        if (npc.talkPressed)
        {
            activateLevel();
        }

    }
    void activateLevel()
    {
        Level.SetActive(true);
        activateFirstObj.SetActive(true);
    }
}

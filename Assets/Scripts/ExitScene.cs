using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScene : MonoBehaviour
{
    public GameObject disableButton;
    public UnlockDoor nextScene;
    public GameObject disableTimer;

    private void OnTriggerEnter(Collider other)
    {
        disableButton.SetActive(false);
        nextScene.NextLevel(); //level result
        disableTimer.SetActive(false);
    }
}
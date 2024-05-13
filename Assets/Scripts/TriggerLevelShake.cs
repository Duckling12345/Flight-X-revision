using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelShake : MonoBehaviour
{
    public Shake shaker;
    public Shake shaker2;
    public NPCConversation myConversation;
    public GameObject DialogueButton;
    public GameObject playerJoystick;
    public GameObject npcIcon;

    void Awake()
    {
            shaker.ShakeScreen();
            shaker2.ShakeScreen();
            ConversationManager.Instance.StartConversation(myConversation);
            DialogueButton.SetActive(false);
            playerJoystick.SetActive(false);
    }

    private void Update()
    {
        Invoke("RemoveDialogue", 14f);
    }

    void RemoveDialogue()
    {
        this.gameObject.SetActive(false);
        playerJoystick.SetActive(true);
        npcIcon.SetActive(false);
    }

    private void OnDisable()
    {
        ConversationManager.Instance.EndConversation();
    }
}

using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{

    public NPCConversation myConversation;
    public GameObject optionsButton;
    public GameObject CaptainSprite;

    private void OnEnable()
    {
        CaptainSprite.SetActive(true);
        ConversationManager.Instance.StartConversation(myConversation);
        optionsButton.SetActive(false);
    }
    

    private void OnDisable()
    {
        ConversationManager.Instance.EndConversation();   
    }


}

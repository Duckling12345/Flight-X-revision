using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{

    public NPCConversation myConversation;
    public GameObject optionsButton;
    public GameObject CaptainSprite;
    public int waitTime;


    private void OnEnable()
    {
        CaptainSprite.SetActive(true);
        ConversationManager.Instance.StartConversation(myConversation);
        optionsButton.SetActive(false);
        Invoke("disableConversation", waitTime);
    }
    

    void disableConversation()
    {
        CaptainSprite.SetActive(false);
        ConversationManager.Instance.EndConversation();   
    }


}

using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartDemo : MonoBehaviour
{
    public string objective;
    public string objective2;
    public string objective3;

    public TMP_Text changeText;
    public TMP_Text changeText2;
    public TMP_Text changeText3;

    public GameObject Buttons;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip Intro;
    [SerializeField] Animator popupAnimator;
    public NPCConversation myConversation;
    public GameObject sprite;



    void Awake()
    {
        StartCoroutine(DelayButtons());
        Invoke("ShowObjective", 2f);
        changeText.text = objective;
        changeText.color = Color.black;

        changeText2.text = objective2;
        changeText3.text = objective3;
        ConversationManager.Instance.StartConversation(myConversation);
        Invoke("EndConversation", 12f);
        sprite.SetActive(true);
    }

    IEnumerator DelayButtons() { 
    
        for (int i = 0; i < Intro.length; i++)
        {
                Buttons.SetActive(true);
            
            while (soundSource.isPlaying)
            {
                Buttons.SetActive(false);
                yield return null;
            }
        }
    }

    void ShowObjective ()
    {
        popupAnimator.Play("PopUpAnimation");
    }

   void EndConversation()
    {
        ConversationManager.Instance.EndConversation();
        sprite.SetActive(false);

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.EventSystems;
//using Unity.PlasticSCM.Editor.WebApi;
//using Palmmedia.ReportGenerator.Core;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class NPCScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public NPCConversation myConversation;
    public bool talkPressed;
    public GameObject talkButton;
    private PopupWindow popupWindow;
    public TMP_Text objectiveText;
    public GameObject objectiveText1;
    public GameObject objectiveText2;
    public GameObject obstacle;
    private GameOverManager gameOver;
    public GameObject removeImage;
    public GameObject okayButton;
    public float timetowait;


    void Start()
    {
        talkButton.SetActive(false);

    }

    private void Update()
    {
        StartConversation();
    }

   public void StartConversation()
    {
        if (talkPressed)
        {
            ConversationManager.Instance.StartConversation(myConversation);
            ShowText();
            RemoveText();
            removeImage.SetActive(true);
            okayButton.SetActive(false);
            Invoke("endConvo", timetowait);
        }
    }



   void RemoveText()
    {
        obstacle.GetComponent<BoxCollider>().enabled = false;
        objectiveText.color = new Color32(0xC0, 0xC0, 0xC0, 0xFF);
    }


    private void OnTriggerEnter(Collider other)
    {
        talkButton.SetActive(true);
    }
    public void ShowText()
    {
        objectiveText1.SetActive(true);
        objectiveText2.SetActive(true);
    }

    public  void endConvo()
    {
        ConversationManager.Instance.EndConversation();
    }




    //temporary fix
    private void OnTriggerExit(Collider other)
    {
        talkButton.SetActive(false);
        ConversationManager.Instance.EndConversation();
        removeImage.SetActive(false);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        talkPressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        talkPressed = false;
    }
}

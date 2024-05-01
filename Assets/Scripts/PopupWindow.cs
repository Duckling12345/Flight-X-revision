using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PopupWindow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Scene scene;
    public GameObject ObjectiveNotification;
    public GameObject window;
    private Animator popupAnimator;
    private Coroutine queueChecker;
    public TMP_Text popupText;
    public List<ObjectiveList> objectiveList;
    private Queue<string> popUpQueue;
    public TMP_Text[] texts;
    public bool clipPressed;
    private int currentObjectives;
    private ObjectiveScript objectiveScript;




    private void Start()
    {
        TexttoArray();
        scene = SceneManager.GetActiveScene();
        popupAnimator = window.GetComponent<Animator>();
        popUpQueue = new Queue<string>();
        Debug.Log(currentObjectives);

        //switch case gets the current scene displays pop up based on current scene;
        switch (scene.buildIndex)
        {
            case 7:
                ShowPopup("Level 1 | Pre-flight Checking");
                break;

            case 12:
                ShowPopup("Level 2 | Loss of Pressurization");
                break;

            case 16:
                ShowPopup("Level 3 | Fire on Board");
                break;
            case 20:
                ShowPopup("Level 4 | Water Landing");
                break;
            default:
                ShowPopup("Level 1 | In-Flight Safety Demo");
                break;
        }


    }
    private void Update()
    {
        if (clipPressed && scene.buildIndex == 7)
        {
            ShowPopup("Level 1 | Pre-flight Checking");
        }
        else if (clipPressed && scene.buildIndex == 10)
        {
            ShowPopup("Level 2 | Loss of Pressurization");
        }
        else if (clipPressed && scene.buildIndex == 12)
        {
            ShowPopup("Level 3 | Fire on Board");

        }
        else if (clipPressed && scene.buildIndex == 14)
        {
            ShowPopup("Level 4 | Water Landing");
        }
        else if(clipPressed)
        {
            ShowPopup("Level 1 | In-Flight Safety Demo");
        }
    }

    public void AddtoQueue(string objectives)
    {
        popUpQueue.Enqueue(objectives);
        if (queueChecker == null)
        {
            queueChecker = StartCoroutine(CheckQueue());
        }
    }
    public void ShowPopup(string objectives)
    {
        window.SetActive(true);
        popupText.text = objectives;
        popupAnimator.Play("PopUpAnimation");
        Debug.Log("Printed Objective");
    }

    private IEnumerator CheckQueue()
    {
        do
        {
            ShowPopup(popUpQueue.Dequeue());
            do
            {
                yield return null;
            } while (!popupAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));
        } while (popUpQueue.Count > 0);
        window.SetActive(false);
        queueChecker = null;
    }

    void TexttoArray()
    {
        //currentObjectives = objectiveScript.objectives.Count;
        int childCount = ObjectiveNotification.transform.childCount;
        texts = new TMP_Text[childCount];

        for (int i = 0; i < childCount; i++)
        {
            texts[i] = ObjectiveNotification.transform.GetChild(i).GetComponent<TMP_Text>();
            texts[i].text = objectiveList[i].Object;
        }
    }



    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        clipPressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        clipPressed = false;
    }
}

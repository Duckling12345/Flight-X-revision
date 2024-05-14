using HUDIndicator;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class PreflightScript : MonoBehaviour
{
    public GameObject objectIndicator;
    public GameObject startLevelObject;
    public GameObject obstacle;
    public FixedTalkButton talkButton;

    [SerializeField] Animator popupAnimator;

    private void Update()
    {
        if (talkButton.Pressed == true)
        {
            obstacle.GetComponent<BoxCollider>().enabled = false;
            objectIndicator.SetActive(true);
            startLevelObject.SetActive(true);
            popupAnimator.Play("PopUpAnimation");

        }
    }
}




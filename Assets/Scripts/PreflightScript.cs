using HUDIndicator;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class PreflightScript : MonoBehaviour
{
    public GameObject objectIndicator;
    public GameObject startLevelObject;

    public FixedTalkButton talkButton;

    [SerializeField] Animator popupAnimator;

    private void Update()
    {
        if (talkButton.Pressed == true)
        {
            objectIndicator.SetActive(true);
            startLevelObject.SetActive(true);
            popupAnimator.Play("PopUpAnimation");

        }
    }
}




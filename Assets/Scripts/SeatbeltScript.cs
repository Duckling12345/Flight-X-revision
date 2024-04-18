using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SeatbeltScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool Pressed;
    public FixedSeatbeltButton fixedSeatbelt;
    [SerializeField] Animator BuckleAnim;
    public GameObject CameraAnimation;
    public string StateName;
    public GameObject tempDisable;
    public Shake shaker;
    public GameObject activateNext;
    public GameObject deactivateCurrent;
    public GameObject seatbeltObject;
    public GameObject InteractButton;
    public GameObject DestroyOnExit;

    void Update()
    {
        if (fixedSeatbelt.Pressed)
        {
            FastenSeatbelt();
        }
    }
    void FastenSeatbelt()
    {
        CameraAnimation.SetActive(true);
        BuckleAnim.Play(StateName);
        tempDisable.SetActive(false);
        activateNext.SetActive(true);
        deactivateCurrent.SetActive(false);
        seatbeltObject.SetActive(true);
        AudioManager.Instance.PlayBuckleSound();
        Invoke("destroyObjects", 4f);
    }


    public void destroyObjects()
    {
        DestroyOnExit.GetComponent<BoxCollider>().enabled = false;
        CameraAnimation.SetActive(false);
        tempDisable.SetActive(true);
        InteractButton.SetActive(false);
    }

   

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
       Pressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstAidScript : MonoBehaviour
{
    public FixedButton fixbutton;
    public GameObject active;
    public GameObject inactive;
    public GameObject activateVest;
    public GameObject disableButton;
    public bool grabPressed;

    public GameObject ActivateIndicator;
    public GameObject DeactiveIndicator;

    void Update()
    {
        if (fixbutton.Pressed == true)
        {
            inactive.SetActive(false);
            active.SetActive(true);
            disableButton.SetActive(false);
            ActivateIndicator.SetActive(true);
            DeactiveIndicator.SetActive(false);
        }
    }


}

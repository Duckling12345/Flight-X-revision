using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WrongScript : MonoBehaviour
{
    public GameObject button1;
    public Button wrongbutton;
    public GameObject panel;



    private void OnTriggerEnter(Collider other)
    {
        button1.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        button1.SetActive(false);
    }

    public void RemoveInteract()
    {
        panel.SetActive(true);
        wrongbutton.interactable = false;
    }

    private void OnDisable()
    {
        wrongbutton.interactable = true;
        button1.SetActive(false);
        panel.SetActive(false);
    }






}

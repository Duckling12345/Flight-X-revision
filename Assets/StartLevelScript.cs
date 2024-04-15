using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelScript : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    public GameObject Active;
    public GameObject Default;
    public GameObject InteractButton;
    public GameObject objectIndicator;

    public FixedButton fixedButton;
 

    // Update is called once per frame
    void Update()
    {
        if (fixedButton.Pressed == true)
        {
            objectIndicator.SetActive(false);
            transitionAnim.SetTrigger("Start");
            Active.SetActive(true);
            Default.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractButton.SetActive(true);
    }



}

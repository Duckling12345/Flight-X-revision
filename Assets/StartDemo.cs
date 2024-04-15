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




    void Awake()
    {
        StartCoroutine(DelayButtons());
        Invoke("ShowObjective", 2f);
        changeText.text = objective;
        changeText.color = Color.black;

        changeText2.text = objective2;
        changeText3.text = objective3;

        
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



}

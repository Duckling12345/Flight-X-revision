using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SequenceCheck : MonoBehaviour
{
    [SerializeField]

    private string correctSequence, currentSequence;
    public UnlockDoor sceneMover;
    [SerializeField] Animator NPCanimation;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip seatbeltIntro;
    [SerializeField] AudioClip oxyIntro;
    [SerializeField] AudioClip vestIntro;
    [SerializeField] AudioClip outro;

    public string stateName;
    public string stateName2;
    public string stateName3;


    public int delayTime;


    private void Start()
    {
        Buttons.SendColorValue += AddValueAndCheckSequence;
        correctSequence = "213";
        currentSequence = "";
    }


    private void AddValueAndCheckSequence(string buttonColor)
    {
        switch (buttonColor)
        {
            case "LifeVest":
                soundSource.PlayOneShot(vestIntro);
                currentSequence += 1;
                NPCanimation.Play(stateName);
                break;

            case "Seatbelt":
                soundSource.PlayOneShot(seatbeltIntro);
                currentSequence += 2;
                NPCanimation.Play(stateName2);
                break;

            case "Oxygen":
                soundSource.PlayOneShot(oxyIntro);
                currentSequence += 3;
                NPCanimation.Play(stateName3);
                break;
        }

        if(currentSequence != correctSequence.Substring(0, currentSequence.Length))
        {
            currentSequence = "";
            Debug.Log("Incorrect");
        } else if (currentSequence == correctSequence)
        {
            currentSequence = "";
            Invoke("OutroSound", 8f);
            Invoke("DelayTransition", delayTime);
        }

    }

    void DelayTransition()
    {
        sceneMover.NextLevel();
    }

    void OutroSound()
    {
        soundSource.PlayOneShot(outro);

    }

    private void OnDestroy()
    {
        Buttons.SendColorValue -= AddValueAndCheckSequence;

    }

}

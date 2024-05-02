using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossSequenceCheck : MonoBehaviour
{
    [SerializeField]

    private string correctSequence, currentSequence;
    public UnlockDoor sceneMover;
    [SerializeField] Animator NPCanimation;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip[] seatbeltIntro;
    [SerializeField] AudioClip[] oxyIntro;
    [SerializeField] AudioClip[] vestIntro;
    [SerializeField] AudioClip outro;
    [SerializeField] AudioClip failedSound;
    [SerializeField] Animator transitionAnim;
    public GameObject ActivateBelt;
    public GameObject ActivateVest;
    public GameObject ActivateOxygen;

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
            case "Brace":
                currentSequence += 1;
                NPCanimation.Play(stateName); //Player Animation
                ActivateVest.SetActive(true);
                ActivateBelt.SetActive(false);
                StartCoroutine(PlayVestIntro());

                break;

            case "Seatbelt":
                currentSequence += 2;
                NPCanimation.Play(stateName2); //Player Animation
                ActivateBelt.SetActive(true);
                StartCoroutine(PlaySeatbeltIntro());
                break;

            case "Oxygen":
                currentSequence += 3;
                NPCanimation.Play(stateName3); //Player Animation
                ActivateOxygen.SetActive(true);
                StartCoroutine(PlayOxygenIntro());
                break;
        }

        if (currentSequence != correctSequence.Substring(0, currentSequence.Length))
        {
            currentSequence = "";
            Debug.Log("Incorrect");
            if (soundSource.isPlaying)
            {
                soundSource.Stop();
                soundSource.PlayOneShot(failedSound);
                Invoke("Incorrect", 5f);
            }
        }
        else if (currentSequence == correctSequence)
        {
            currentSequence = "";
            Invoke("OutroSound", 14f);
            Invoke("DelayTransition", delayTime);
        }

    }

    void DelayTransition()
    {
        transitionAnim.SetTrigger("End");
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = true;
    }

    void OutroSound()
    {
        soundSource.PlayOneShot(outro);
    }

    void Incorrect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator PlayVestIntro()
    {
        for (int i = 0; i < vestIntro.Length; i++)
        {
            soundSource.clip = vestIntro[i];

            soundSource.Play();

            while (soundSource.isPlaying)
            {
                yield return null;
            }
        }
    }

    IEnumerator PlaySeatbeltIntro()
    {
        for (int i = 0; i < seatbeltIntro.Length; i++)
        {
            soundSource.clip = seatbeltIntro[i];

            soundSource.Play();


            while (soundSource.isPlaying)
            {
                yield return null;
            }
        }
    }

    IEnumerator PlayOxygenIntro()
    {
        for (int i = 0; i < oxyIntro.Length; i++)
        {
            soundSource.clip = oxyIntro[i];

            soundSource.Play();


            while (soundSource.isPlaying)
            {
                yield return null;
            }
        }
    }


    private void OnDestroy()
    {
        Buttons.SendColorValue -= AddValueAndCheckSequence;

    }

}

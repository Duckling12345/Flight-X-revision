using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossSequenceCheck : MonoBehaviour
{
    [SerializeField]

    private string correctSequence, currentSequence;
    public UnlockDoor sceneMover;
    public MiniGameResult_LOP minigameResult;
    public Shake shaker;
    public GameObject levelResults;
    public GameObject buttons;
    [SerializeField] Animator PlayerAnimation;
    [SerializeField] Animator transitionAnim;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip failedSound;




    public string stateName;
    public string stateName2;
    public string stateName3;


    public int delayTime;

    public void Awake()
    {
        shaker.ShakeScreen();
    }



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
                PlayerAnimation.Play(stateName); //Player Animation

                break;

            case "Seatbelt":
                currentSequence += 2;
                PlayerAnimation.Play(stateName2); //Player Animation
                break;

            case "Last":
                currentSequence += 3;
                PlayerAnimation.Play(stateName3); //Player Animation
                break;
        }

        if (currentSequence != correctSequence.Substring(0, currentSequence.Length))
        {
            currentSequence = "";
            Debug.Log("Incorrect");
           soundSource.PlayOneShot(failedSound);

            
        }
        else if (currentSequence == correctSequence)
        {
            currentSequence = "";
            levelResults.SetActive(true);
            buttons.SetActive(false);
            Invoke("DelayTransition", delayTime);
            minigameResult.MiniGameComplete();
        }

    }



    void Incorrect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

    private void OnDestroy()
    {
        Buttons.SendColorValue -= AddValueAndCheckSequence;

    }

}

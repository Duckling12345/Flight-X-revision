using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssessmentSCheck : MonoBehaviour
{
    public GameOverManager timer;
    public GameObject stars;
    public GameObject object1;
    public GameObject object2;
    public GameObject animcamera;
    public GameObject captainvoice;

    private void Update()
    {
        if(animcamera.activeInHierarchy == true)
        {
            if(object1.activeInHierarchy == true && object2.activeInHierarchy == true)
            {
                timer.GameOver();
                stars.SetActive(false);
                captainvoice.SetActive(false);
            }
        } else
        {
            Debug.Log("Completed");
        }
    }





}

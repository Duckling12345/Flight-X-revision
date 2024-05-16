using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssesmentWater : MonoBehaviour
{
    public GameOverManager timer;
    public GameObject stars;
    public GameObject object1;
    public GameObject levelresult;

    private void OnTriggerEnter(Collider other)
    {
 
            if (object1.activeInHierarchy == true)
            {
                timer.GameOver();
                stars.SetActive(false);
                levelresult.SetActive(false);
            }
            else
            {
            Debug.Log("Completed");
         }
    }
}

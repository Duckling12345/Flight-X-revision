using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssessmentFire : MonoBehaviour
{
    public FixedButton interact;
    public GameOverManager timer;
    public GameObject stars;
    public GameObject object1;

    private void Update()
    {

        if (interact.Pressed)
        {
            if (object1.activeInHierarchy == true)
            {
                timer.GameOver();
                stars.SetActive(false);

            }
        }
        else
        {
            Debug.Log("Completed");
        }
    }
}

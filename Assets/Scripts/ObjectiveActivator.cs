    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveActivator : MonoBehaviour
{
    private ObjectiveScript objectiveScript;
    private bool ObjectiveActive = false;
    public GameObject InteractButton;
    //public GameObject DestroyOnExit;
    
    // Start is called before the first frame update
    void Start()
    {
        objectiveScript = FindAnyObjectByType<ObjectiveScript>();

    }

   public void ActivateObjective()
    {
        ObjectiveActive = true;
        //DestroyOnExit.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (ObjectiveActive)
        {
            Debug.Log("Player Entrered the collider");
            objectiveScript.nextObjective();
            InteractButton.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Exited");
        //DestroyOnExit.GetComponent<BoxCollider>().enabled =false;
    }
}

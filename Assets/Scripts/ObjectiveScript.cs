using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveScript : MonoBehaviour
{
    private List<Transform> objectives = new List<Transform>();
    public Material activeObjectives;
    public Material inactiveObjectives;
    public Material finalObjectives;
    public int sceneBuildIndex;
    public int objectivesDone;


   
    private void Start()
    {
        foreach(Transform t in transform)
        {
            objectives.Add(t);     
            t.GetComponent<MeshRenderer>().material = inactiveObjectives;
        }

        if(objectives.Count == 0) {
            Debug.Log("No objectives at this level please add ty");
            return;
        }
    
        objectives[objectivesDone].GetComponent<MeshRenderer>().material = activeObjectives;
        objectives[objectivesDone].GetComponent<ObjectiveActivator>().ActivateObjective();
    }

    public void nextObjective()
    {
        objectivesDone++;

        Debug.Log("Objectives finished: " + objectivesDone);
        Debug.Log("Objectives remaining: " + objectives.Count);

        //final objective code
      

            if (objectivesDone == objectives.Count)
            {
                Debug.Log("Level Complete!");
                Victory();
                return;
            }
        
        if (objectivesDone == objectives.Count - 1) {  
        
            objectives[objectivesDone].GetComponent<MeshRenderer>().material = finalObjectives;
        }
        else {  
             objectives[objectivesDone].GetComponent<MeshRenderer>().material = activeObjectives;
        }
        //idk what this is 
        objectives[objectivesDone].GetComponent<ObjectiveActivator>().ActivateObjective();
    }
    private void Victory()
    {
       // SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        Debug.Log("Proceed to next level");
    }
}

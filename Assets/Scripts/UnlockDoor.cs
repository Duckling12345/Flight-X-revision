using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;

public class UnlockDoor : MonoBehaviour
{
    public static UnlockDoor instance;
    [SerializeField] Animator transitionAnim;
    public void NextLevel()
    {
        
        StartCoroutine(LoadLevel());
    }

    public void NextLevelDelay()
    {
        StartCoroutine(LoadLevelDelay());
    }



    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(3);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = true;
        transitionAnim.SetTrigger("Start");
    }

    IEnumerator LoadLevelDelay()
    {
        yield return new WaitForSeconds(3);
        transitionAnim.SetTrigger("End");
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = true;
        transitionAnim.SetTrigger("Start");
    }
}
   



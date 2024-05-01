using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartStop : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;


    private void Start()
    {

    }

    public void SkipPrologue()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = true;
        transitionAnim.SetTrigger("End");

    }
}

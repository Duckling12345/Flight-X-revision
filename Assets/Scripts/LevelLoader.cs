using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen0;
    public GameObject loadingScreen1;
    public GameObject loadingScreen2;
    public GameObject loadingScreen3;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        // Activate the loading screen
        switch (sceneIndex)
        {
            case 6:
                loadingScreen0.SetActive(true);
                break;
            case 9:
                loadingScreen1.SetActive(true);
                break;
            case 12:
                loadingScreen3.SetActive(true);
                break;
            case 15:
                loadingScreen2.SetActive(true);
                break;
        }

        // Load the scene immediately
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            // Update loading progress
            yield return null;
        }

        // Scene loaded, update images and text
        SceneLoad(sceneIndex);
    }

    public void SceneLoad(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 6:
                // Update title for sceneIndex 6
                break;
            case 9:
                // Update title for sceneIndex 7
                break;
            case 12:
                // Update title for sceneIndex 8
                break;
            case 15:
                // Update title for sceneIndex 9
                break;
        }
    }
}

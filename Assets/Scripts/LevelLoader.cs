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

    public Button[] buttons;

    //Locks Level
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i< buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }


    //Loads Level
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
            case 10:
                loadingScreen1.SetActive(true);
                break;
            case 12:
                loadingScreen3.SetActive(true);
                break;
            case 14:
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
    }

}

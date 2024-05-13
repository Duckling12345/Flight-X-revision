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
    public Sprite lockedImg;

    //Locks Level
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < unlockedLevel)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
                // Set a locked level icon
                Image buttonImage = buttons[i].GetComponent<Image>();
                if (buttonImage != null && lockedImg != null)
                {
                    buttonImage.sprite = lockedImg;
                }
            }
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
            case 12:
                loadingScreen1.SetActive(true);
                break;
            case 18:
                loadingScreen3.SetActive(true);
                break;
            case 24:
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public void nextScene() 
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void playGame()
    {
        SceneManager.LoadScene("Level Modules");
    }
    public void gotoInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void gotoOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void gotoAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void gotoSummaryOfScores()
    {
        SceneManager.LoadScene("Summary");
    }
    public void backtoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void backtoLevelSelection()
    {
        SceneManager.LoadScene("Level Modules");
    }
    public void quitGame ()
    {
        Application.Quit();
    }
}

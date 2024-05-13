using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConclusionScript : MonoBehaviour
{
    public NPCConversation concluConversation;
    
    public GameObject optionsButton;
    public GameObject npcSprite;
    public GameObject conclusionPanel;
    
    public int timetoWait;
    public int showConclusionTime;

    [SerializeField] Animator transitionAnim;
    [SerializeField] Animator devsAnim;

    private bool devAnimationPlayed = false;

    void Awake()
    {
        ConversationManager.Instance.StartConversation(concluConversation); 
        optionsButton.SetActive(false);
    }

    void Update()
    {
        Invoke("EndScene", timetoWait);
        Invoke("ShowPanel", showConclusionTime);
    }

    void EndScene()
    {
        npcSprite.SetActive(false);
        ConversationManager.Instance.EndConversation();
        transitionAnim.SetTrigger("End");
    }

    void ShowPanel()
    {
        if (!devAnimationPlayed && devsAnim != null)
        {
            conclusionPanel.SetActive(true);
            devsAnim.Play("Devs");
            devAnimationPlayed = true;
            StartCoroutine(StopAnimationAfterDelay(30, devsAnim.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    IEnumerator StopAnimationAfterDelay(int sampleSize, float animationLength)
    {
        float sampleLength = animationLength / sampleSize;
        yield return new WaitForSeconds(sampleLength * sampleSize); 
        devsAnim.enabled = false;
    }


    public void BackToMenu()
    {
        Time.timeScale += Time.deltaTime;
        SceneManager.LoadScene("Level Modules");
    }
}

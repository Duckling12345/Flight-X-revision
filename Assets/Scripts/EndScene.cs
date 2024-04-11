using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public FireScript fireScript;
    public UnlockDoor sceneMover;
    public ParticleSystem partikol;
    [SerializeField] AudioSource audioSource;
    public GameObject levelResult;
    public GameObject playerUI;

    // Update is called once per frame
    void Update()
    {
        Invoke("FadetoBlack", 5f);
    }
    void LevelResult()
    {
        levelResult.SetActive(true);
        playerUI.SetActive(false);
        GetComponent<StarsHandler>().starsAchieved();
        Time.timeScale = 0f;
    }
    private void FadetoBlack()
    {
        int numbers = partikol.particleCount;
        if (fireScript.isLit == false && numbers == 0)
        {
            audioSource.Stop();
            LevelResult();
        }
    }
    
}

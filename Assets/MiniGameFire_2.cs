using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameFire_2 : MonoBehaviour
{
    public FixedExtinguishButton fixedExtinguish;
    public ObjectiveScript objective;
    public TMP_Text objectiveText1;
    public string extObjective;
    public int objectiveID;
    [SerializeField] Animator popupAnimator;

    public GameObject removeButton;
    public GameObject levelResult;
    public GameObject playerUI;
    public GameObject timer;

    private void Update()
    {
            if (fixedExtinguish.buttonPressed)
            {
                Invoke("playAnimation",5f);
            }
    }

    public void playAnimation()
    {
        MGResult();
    }

    void MGResult()
    {
        levelResult.SetActive(true);
        playerUI.SetActive(false);
        timer.SetActive(false);
    }
}

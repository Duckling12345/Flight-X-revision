using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Buttons[] button;


    void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            Debug.Log(button[i].name);
        }
    }

    void Update()
    {
        
    }
}

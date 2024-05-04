using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public GameOverManager timer;
    [SerializeField] private float shakeDuration;
    public float shakeIntensity;

    private Vector3 initialPosition;
    private float currentShakeDuration;


    void Start()
    {
        initialPosition = transform.localPosition;   
    }


    void Update()
    {
        if(currentShakeDuration > 0)
        {
         Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;
         transform.localPosition = initialPosition + randomOffset;
         currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = initialPosition;
        }
      
    }

    public void ShakeScreen()
    {
        currentShakeDuration = timer.remainingTime;
    }
}

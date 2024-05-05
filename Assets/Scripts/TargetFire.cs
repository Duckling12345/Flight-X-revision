using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFire : MonoBehaviour
{
    public float damage = 10f;
    public float impactForce = 100f;
    public float range = 100f;
    public float extinguishRate = 15f;

    public Camera FPSCam;
    public GameObject crosshair; // Change type to GameObject

    private float nextTimeToExtinguish = 0f;

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && Time.time >= nextTimeToExtinguish)
        {
            nextTimeToExtinguish = Time.time + 1f / extinguishRate;
            Target();
        }
    }

    public void Target()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit object: " + hit.transform.name); // Debug log to check the object hit by the raycast

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (hit.transform.gameObject == crosshair) // Check if the hit object is the crosshair GameObject
            {
                // Extinguish the fire by deactivating its GameObject
                hit.transform.gameObject.SetActive(false);
            }
            else
            {
                // Additional actions if needed
            }
        }
    }
}

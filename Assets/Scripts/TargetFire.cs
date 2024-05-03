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
    private float nextTimeToExtinguish = 0f;

    private void Update()
    {
        if (Input.GetButtonDown("WildFire (test)") && Time.time >= nextTimeToExtinguish)
        {
            nextTimeToExtinguish = Time.time + 1f / extinguishRate;
            Target();
        }
    }

    void Target()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            if (hit.rigidbody != null) 
            { 
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}

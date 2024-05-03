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
    public Transform crosshair; // Reference to the crosshair object

    private float nextTimeToExtinguish = 0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToExtinguish)
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

            // Check if the crosshair is aligned with the fire extinguisher
            if (hit.transform == crosshair)
            {
                // Extinguish the fire by stopping the emission
                hit.transform.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                // Apply damage if it's not the fire particle system
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}

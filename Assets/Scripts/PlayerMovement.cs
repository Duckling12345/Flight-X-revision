using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick joystick;
    public float SpeedMove = 3f;
    public CharacterController controller;

    public Transform InteractorSource;
    public float InteractRange;
    public bool Pressed;

    private float Gravity = -9.81f;
    public float groundDistance = 0.3f;
    public Transform Ground;
    public LayerMask layermask;
    Vector3 velocity;
    public DoorScript doorScript;
    public bool isGround;
    public bool Opening;
    public Animator Animation;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Opening = false;
    }

    public void Update()
    {
        isGround = Physics.CheckSphere(Ground.position, groundDistance, layermask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(Move * SpeedMove * Time.deltaTime);

        if (Pressed)
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }

            if (Physics.Raycast(InteractorSource.position, InteractorSource.forward, out hitInfo, InteractRange))
            {
                if (hitInfo.transform.tag == "Door")
                {
                    doorScript = hitInfo.transform.GetComponent<DoorScript>();
                    if (doorScript.Close)
                    {
                        if (Pressed)
                        {
                            OpenTime();
                            Debug.Log("napindot");
                            Opening = true;
                            Animation.SetBool("Opening", Opening);
                        }
                    }
                }
            }
        }

        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void OpenTime()
    {
        doorScript.Close = false;
        doorScript.Open = true;
    }

    // Triggered when player collides with a trigger collider
  
}
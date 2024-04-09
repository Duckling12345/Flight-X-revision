using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{
    public FixedSeatbeltButton fixedSeatbelt;
    public SeatbeltScript seatbelt;

    public FixedSitButton fixedSitButton;
    public ChairInteraction chairInteraction;

    public FixedTouchField touchField;
    public CameraLook cameraLook;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraLook.LockAxis = touchField.TouchDist;
        seatbelt.Pressed = fixedSeatbelt.Pressed;
        chairInteraction.Pressed = fixedSitButton.Pressed;
    }
}

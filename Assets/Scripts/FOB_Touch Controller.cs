using UnityEngine;

public class FOB_TouchController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField;
    public CameraLook _CameraLook;
    public PlayerMovement _PlayerMovement;
    public FixedButton _FixedButton;
    public PauseMenu _PauseMenu;
    public PauseFixedButton _PauseFixedButton;
    public FixedClipboardButton _FixedClipboardButton;
    public PopupWindow _PopupWindow;
    //public TargetFire _TargetFire; // Reference to your TargetFire script

    void Update()
    {
        // Pass touch input for camera movement
        _CameraLook.LockAxis = _FixedTouchField.TouchDist;

        // Pass touch input for player movement
        _PlayerMovement.Pressed = _FixedButton.Pressed;

        // Pass touch input for pausing the game
        _PauseMenu.buttonPressed = _PauseFixedButton.Pressed;

        // Pass touch input for interacting with UI elements
        _PopupWindow.clipPressed = _FixedClipboardButton.Pressed;

        // Handle firing action
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
            // Call the fire method in the TargetFire script
            //_TargetFire.Target();
        //}
    }
}

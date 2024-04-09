using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2 MoveInput;

    public void OnMove(InputValue input) => MoveInput = input.Get<Vector2>();
}
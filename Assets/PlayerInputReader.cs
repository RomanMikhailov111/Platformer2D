using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        _player.SetDirection(dir);
    }
}

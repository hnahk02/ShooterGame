using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    public static GameInput Instance;

    public event EventHandler OnAimAction;

    private PlayerInputAction _playerInputAction;



    private void Awake()
    {
        Instance = this;
        _playerInputAction = new PlayerInputAction();
    }

    private void Start()
    {
        _playerInputAction.Player.Enable();
        _playerInputAction.Player.Aim.performed += Aim_performed; ;
    }

    public Vector2 GetPlayerMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>().normalized;  
        return inputVector;
    }

    private void Aim_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnAimAction?.Invoke(this, EventArgs.Empty);
    }
}

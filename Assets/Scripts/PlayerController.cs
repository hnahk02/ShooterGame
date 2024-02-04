using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationSpeed = .8f;
    private Transform _cameraTransform;

    public event EventHandler OnRunningAction;

    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        Vector2 input = GameInput.Instance.GetPlayerMovementVectorNormalized();

        Vector3 moveDir = new Vector3(input.x, 0f, input.y);

        // Move player along with transform of main camera
        moveDir = moveDir.x * _cameraTransform.right.normalized + moveDir.z * _cameraTransform.forward.normalized;
        moveDir.y = 0f;

        if(moveDir != Vector3.zero)
        {
            transform.position += moveDir * _speed * Time.deltaTime;
            OnRunningAction?.Invoke(this, EventArgs.Empty);
        }

        //Rotate toward camera directions
        float targetAngle = _cameraTransform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed);


    }

}

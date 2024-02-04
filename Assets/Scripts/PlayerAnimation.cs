using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string RUNNING = "IsRunning";

    private Animator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayerController.Instance.OnRunningAction += PlayerController_OnRunningAction;
    }

    private void PlayerController_OnRunningAction(object sender, System.EventArgs e)
    {
        _playerAnimator. SetBool(RUNNING, true);
    }
}

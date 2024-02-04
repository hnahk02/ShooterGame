using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonController : MonoBehaviour
{
    private bool _togglePlayerAimCamera;

    [SerializeField] private CinemachineVirtualCamera _playerAimCamera;
    [SerializeField] private Canvas _thirdPersonCanvas;
    [SerializeField] private Canvas _aimCanvas;

    private void Start()
    {
        HanldlePlayerCanvas();
        GameInput.Instance.OnAimAction += GameInput_OnAimAction;
        _playerAimCamera.gameObject.SetActive(false);   
        
    }

    private void Update()
    {
        
    }


    private void GameInput_OnAimAction(object sender, System.EventArgs e)
    {
        _togglePlayerAimCamera = !_togglePlayerAimCamera;
        _playerAimCamera.gameObject.SetActive(_togglePlayerAimCamera);
        HanldlePlayerCanvas();
    }

    private void HanldlePlayerCanvas()
    {
        if(_togglePlayerAimCamera)
        {
            _thirdPersonCanvas.enabled = false;
            _aimCanvas.enabled = true;
        }
        else
        {
            _thirdPersonCanvas.enabled = true;
            _aimCanvas.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicateMoveInputToPlayerAvatar : MonoBehaviour
{

    private Vector2 _moveInput = Vector2.zero;
    private Vector3 _moveDirection = Vector3.zero;
    [SerializeField] MoveObject _playerAvatarMoveScriptReference;
    [SerializeField] GameObject _cameraView;
    private bool _errorDetected = false;


    private void Awake()
    {
        if (_playerAvatarMoveScriptReference == null)
        {
            _errorDetected = true;
            Debug.LogError("'MoveObject' reference null on object: " + gameObject);
        }
    }

    private void Update()
    {
        if (!_errorDetected)
        {
            BuildVector3DirectionFromVector2Input();
            CommunicateMoveDirectionToAvatar();
        }

    }

    private void BuildVector3DirectionFromVector2Input()
    {
        _moveInput = InputDetector.Instance.GetMoveInput();

        _moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
    }

    private void CommunicateMoveDirectionToAvatar()
    {
        _playerAvatarMoveScriptReference.SetDirection(_moveDirection);
    }
}

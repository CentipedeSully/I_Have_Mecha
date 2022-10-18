using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicateMoveInputToPlayerAvatar : MonoBehaviour
{

    [SerializeField] private Vector2 _moveInput = Vector2.zero;
    [SerializeField] private Vector3 _moveDirection = Vector3.zero;
    [SerializeField] MoveObject _playerAvatarMoveScriptReference;

    private void Update()
    {
        BuildVector3DirectionFromVector2Input();
        CommunicateMoveDirectionToAvatar();
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

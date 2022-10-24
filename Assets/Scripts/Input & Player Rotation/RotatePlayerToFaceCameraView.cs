using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SullysToolkit;

public class RotatePlayerToFaceCameraView : MonoBehaviour
{
    //Lerp's duration
    [SerializeField] private float _rotationDuration = .2f;
    [SerializeField] private float _cameraViewYaw;
    [SerializeField] private float _playerYaw;
    [SerializeField] private float _moveInputDirection;

    [SerializeField] private GameObject _cameraObject;

    [SerializeField] private GameObject _playerBody;

    [SerializeField] private LerpValueOverTime _lerperReference;




    private void Update()
    {
        GetCurrentObjectRotations();

        if ( IsPlayerMoving() && _playerYaw != _cameraViewYaw)
            LerpPlayerRotationToCameraRotation();
    }




    private bool IsPlayerMoving()
    {
        if (InputDetector.Instance.GetMoveInput() != Vector2.zero)
            return true;
        else return false;
    }

    private void GetCurrentObjectRotations()
    {
        //Get current rotations
        _playerYaw = _playerBody.transform.rotation.eulerAngles.y;
        _cameraViewYaw = _cameraObject.transform.rotation.eulerAngles.y;

        _moveInputDirection = Mathf.Atan2(InputDetector.Instance.GetMoveInput().x, InputDetector.Instance.GetMoveInput().y) * Mathf.Rad2Deg;  
    }

    private void LerpPlayerRotationToCameraRotation()
    {
        

        //clamp yaws to [-360,360] degree range
        _playerYaw = RotateCameraViewByInput.ClampAngle(_playerYaw, float.MinValue, float.MaxValue);
        _cameraViewYaw = RotateCameraViewByInput.ClampAngle(_cameraViewYaw, float.MinValue, float.MaxValue);

        if (_playerYaw != _cameraViewYaw)
        {
            if (_lerperReference.IsLerping() == false || _lerperReference.IsLerping() == true && _lerperReference.GetTargetValue() != _cameraViewYaw + _moveInputDirection)
            {
                _lerperReference.SetLerp(_playerYaw, _cameraViewYaw + _moveInputDirection, _rotationDuration, true);
                _lerperReference.StartLerp();
            }
        }

        
    }

    public void ReadLerpResultIntoPlayerYaw(float result)
    {
        _playerBody.transform.rotation = Quaternion.Euler(0, result, 0); ;
    }
}

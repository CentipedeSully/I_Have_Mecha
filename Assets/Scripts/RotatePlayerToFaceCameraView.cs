using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerToFaceCameraView : MonoBehaviour
{
    //Lerp's duration
    [SerializeField] private float _rotationDuration = .2f;
    [SerializeField] private float _cameraViewYaw;
    [SerializeField] private float _playerYaw;

    [SerializeField] private GameObject _cameraObject;

    [SerializeField] private GameObject _playerBody;


    private void Update()
    {
        GetCurrentObjectRotations();

        if (IsPlayerMovingForward() && _playerYaw != _cameraViewYaw)
            LerpPlayerRotationToCameraRotation();
    }



    private bool IsPlayerMovingForward()
    {
        if (InputDetector.Instance.GetMoveInput().y > 0 )
            return true;
        else return false;
    }

    private void GetCurrentObjectRotations()
    {
        //Get current rotations
        _playerYaw = _playerBody.transform.rotation.eulerAngles.y;
        _cameraViewYaw = _cameraObject.transform.rotation.eulerAngles.y;
    }

    private void LerpPlayerRotationToCameraRotation()
    {
        

        //clamp yaws to [-360,360] degree range
        _playerYaw = RotateCameraViewByInput.ClampAngle(_playerYaw, float.MinValue, float.MaxValue);
        _cameraViewYaw = RotateCameraViewByInput.ClampAngle(_cameraViewYaw, float.MinValue, float.MaxValue);

        //Lerp
        _playerYaw = Mathf.LerpAngle(_playerYaw, _cameraViewYaw, _rotationDuration);

        _playerBody.transform.rotation = Quaternion.Euler(0, _playerYaw, 0);
    }

}

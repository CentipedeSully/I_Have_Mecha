using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SullysToolkit;

public class RotatePlayerToFaceCameraView : MonoBehaviour
{
    //Lerp's duration
    [SerializeField] private float _rotationDuration;
    [SerializeField] private float _cameraViewYaw;
    [SerializeField] private float _playerYaw;
    [SerializeField] private float _moveInputDirection;

    [SerializeField] private GameObject _cameraObject;

    [SerializeField] private GameObject _playerBody;

    private float _currentDampVelocity = 0;


    private void Update()
    {
        GetCurrentObjectRotations();

        if (_playerYaw != _cameraViewYaw)
            SmoothDampPlayerYawToCameraYaw();
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

    private void SmoothDampPlayerYawToCameraYaw()
    {
        //clamp yaws to [-360,360] degree range
        _playerYaw = RoundToHundreth( RotateCameraViewByInput.ClampAngle(_playerYaw, float.MinValue, float.MaxValue));
        _cameraViewYaw = RoundToHundreth(RotateCameraViewByInput.ClampAngle(_cameraViewYaw, float.MinValue, float.MaxValue));

        if ( _playerYaw != _cameraViewYaw)
        {
            _rotationDuration = CalculateDynamicRotationDuration();
            var result =  Mathf.SmoothDampAngle(_playerYaw, _cameraViewYaw, ref _currentDampVelocity, _rotationDuration);
            _playerBody.transform.rotation = Quaternion.Euler(0, result, 0); ;
        }

        
    }

    private float RoundToHundreth(float value)
    {
        return Mathf.Floor(value * 100) / 100;
    }

    private float CalculateDynamicRotationDuration()
    {
        float difference;

        //Get difference of playerYaw and cameraYaw
        difference = Mathf.Abs(_cameraViewYaw - _playerYaw);

        //Calculate absoluteDistanceBtwn camera yaw and player yaw
        difference = CalculateAbsoluteDistanceFrom180Degrees(difference);

        return (difference / 100) * .5f;



    }

    private float CalculateAbsoluteDistanceFrom180Degrees(float value)
    {
        float absoluteValue = 0;

        //If the angle's value is within the 4th quadrant, reflect it over the y axis into the 1st quadrant
        if (value > 180 && value >= 270)
            absoluteValue = 360 - value;

        //If the angle's value is within the third quadrant, reflect it over the y axis into the 2nd quadrant
        else if (value > 180 && value < 270)
            absoluteValue = value - 2 * (value - 180);

        else absoluteValue = value;

        return absoluteValue;
    }
}

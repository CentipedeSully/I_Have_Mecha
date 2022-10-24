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

    [SerializeField] private LerpValueOverTime _lerperReference;




    private void Update()
    {
        GetCurrentObjectRotations();

        if (_playerYaw != _cameraViewYaw)
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
        _playerYaw = RoundToHundreth( RotateCameraViewByInput.ClampAngle(_playerYaw, float.MinValue, float.MaxValue));
        _cameraViewYaw = RoundToHundreth(RotateCameraViewByInput.ClampAngle(_cameraViewYaw, float.MinValue, float.MaxValue));

        if ( _playerYaw != _cameraViewYaw)
        {
            if (_lerperReference.IsLerping() == false || _lerperReference.IsLerping() == true && _lerperReference.GetTargetValue() != _cameraViewYaw)
            {
                _rotationDuration = CalculateDynamicRotationDuration();
                _lerperReference.SetLerp(_playerYaw, _cameraViewYaw, _rotationDuration, true);
                _lerperReference.StartLerp();
            }
        }

        
    }

    public void ReadLerpResultIntoPlayerYaw(float result)
    {
        _playerBody.transform.rotation = Quaternion.Euler(0, result, 0); ;
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
        //Debug.Log("Difference of CameraYaw - PlayerYaw: " + difference);



        //Calculate absoluteDistanceBtwn camera yaw and player yaw
        difference = CalculateAbsoluteDistanceFrom180Degrees(difference);
        //Debug.Log("AbsoluteDistance of CameraYaw - PlayerYaw: " + difference);

        return (difference / 100) * .5f;



    }

    private float CalculateAbsoluteDistanceFrom180Degrees(float value)
    {
        float absoluteValue = 0;

        if (value > 180 && value >= 270)
            absoluteValue = 360 - value;

        else if (value > 180 && value < 270)
            absoluteValue = value - 2 * (value - 180);

        else absoluteValue = value;

        return absoluteValue;
    }
}

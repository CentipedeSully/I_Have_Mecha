using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraViewByInput : MonoBehaviour
{
    private Vector2 _turnInput = Vector2.zero;
    

    [SerializeField] private GameObject _cinemachineShoulderCamera;
    [SerializeField] private float _turnSpeedMultiplier = .5f;
    [SerializeField] private float _upRotationMax = 70;
    [SerializeField] private float _downRotationMax = -40;

    private float _cameraYaw;
    private float _cameraPitch;
    


    private void Update()
    {
        GetInputFromDetector();
    }

    private void LateUpdate()
    {
        RotateCamera();
    }



    private void GetInputFromDetector()
    {
        _turnInput = InputDetector.Instance.GetTurnInput();
    }

    
    private void RotateCamera()
    {
        //Apply x input to Yaw variable
        _cameraYaw += _turnInput.x * _turnSpeedMultiplier;

        //Apply y input to pitch variable
        _cameraPitch += _turnInput.y * _turnSpeedMultiplier;

        //Clamp both Yaw and Pitch
        _cameraYaw = ClampAngle(_cameraYaw, float.MinValue, float.MaxValue);
        _cameraPitch = ClampAngle(_cameraPitch, _downRotationMax, _upRotationMax);

        //Apply new Yaw and Pitch to Target camera
        _cinemachineShoulderCamera.transform.rotation = Quaternion.Euler(_cameraPitch * -1, _cameraYaw,0);
        
    }


    public static float ClampAngle(float currentValue, float minValue, float maxValue)
    {
        if (currentValue >= 360) currentValue -= 360;
        if (currentValue <= -360) currentValue += 360;

        return Mathf.Clamp(currentValue, minValue, maxValue);
    }






}

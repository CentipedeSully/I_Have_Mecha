using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThisAroundObject : MonoBehaviour
{
    private Vector3 _rotationInstructions = Vector3.zero;

    [SerializeField] private float _rotationSpeed = 10;
    [SerializeField] private GameObject centerOfRotation;

    private void Update()
    {
        RotateAroundObject();
    }

    private void RotateAroundObject()
    {
        transform.RotateAround(centerOfRotation.transform.position,Vector3.up, _rotationSpeed * _rotationInstructions.x * Time.deltaTime);
    }

    public void setRotationInstruction(Vector3 newRotation)
    {
        _rotationInstructions = newRotation;
    }
}

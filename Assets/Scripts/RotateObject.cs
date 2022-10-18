using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private Vector3 _rotationInstructions = Vector3.zero;

    [SerializeField] private float _turnSpeed = 2;
    [SerializeField] private Rigidbody _playerRigidbodyReference;

    private void Update()
    {
        TurnObject();
    }

    private void TurnRigidbody()
    {
        _playerRigidbodyReference.AddTorque(_rotationInstructions * _turnSpeed * Time.deltaTime);
    }

    private void TurnObject()
    {
        transform.Rotate(new Vector3(0,_rotationInstructions.y * _turnSpeed,0));
    }

    public void setRotationInstruction(Vector3 newRotation)
    {
        _rotationInstructions = newRotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection = Vector3.zero;
    [SerializeField] private float _moveSpeed = 100;
    [SerializeField] private Rigidbody _rigidbody;
    private bool _errorDetected = false;

    private void Awake()
    {
        if (_rigidbody == null)
        {
            _errorDetected = true;
            Debug.LogError("RigidBody reference null on object: " + gameObject);
        }
    }


    private void FixedUpdate()
    {
        if (!_errorDetected)
            Move();
    }



    private void Move()
    {
        _rigidbody.AddRelativeForce(_moveDirection  * _moveSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    public Vector3 GetDirection()
    {
        return _moveDirection;
    }

    public void SetSpeed(float newSpeed)
    {
        _moveSpeed = newSpeed;
    }

    public float GetSpeed()
    {
        return _moveSpeed;
    }


}

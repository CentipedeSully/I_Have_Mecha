using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection = Vector3.zero;
    [SerializeField] private float _moveSpeed = 100;
    [SerializeField] private Rigidbody _rigidbody;



    private void FixedUpdate()
    {
        Move();
    }



    private void Move()
    {
        if (_rigidbody != null)
            _rigidbody.AddForce(_moveDirection * _moveSpeed * Time.deltaTime);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCenterPoint : MonoBehaviour
{
    [SerializeField] private GameObject _target;


    private void LateUpdate()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        transform.LookAt(_target.transform);
    }
}

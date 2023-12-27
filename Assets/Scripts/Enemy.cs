using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private float _moveSpeed;

    private Transform _target;

    private void Update()
    {
        ChaseTarget();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void ChaseTarget()
    {
        if (_target == null)
            return;

        Vector3 directionToTarget = (_target.position - transform.position).normalized;

        transform.Translate(_moveSpeed * Time.deltaTime * directionToTarget);
    }
}

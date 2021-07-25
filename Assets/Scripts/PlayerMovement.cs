using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;
using Helper;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField, Range(0.001f, 10f)] private float _movementOffset;
    private Transform _mainCam;

    private void Start()
    {
        if (_navMeshAgent != null) _navMeshAgent = GetComponent<NavMeshAgent>();
        _mainCam = Camera.main.transform;
    }
    private void Update()
    {
        Vector3 moveDir = GetInputs().RelativeToCamera(_mainCam);
        _navMeshAgent.SetDestination(transform.position + moveDir * _movementOffset);
    }


    private Vector3 GetInputs()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

}

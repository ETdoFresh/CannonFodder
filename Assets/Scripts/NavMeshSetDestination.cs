﻿using UnityEngine;
using System.Collections;

public class NavMeshSetDestination : MonoBehaviour
{
    // Prerequisites:
    // == Baked NavMesh
    // == Collider on Ground
    // == NavMeshAgent

    private NavMeshAgent _navMeshAgent;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (_navMeshAgent)
                    _navMeshAgent.SetDestination(hit.point);

            }
        }
    }
}

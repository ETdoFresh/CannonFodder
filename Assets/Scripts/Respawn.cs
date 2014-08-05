using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Vector3 StartPosition;

    void Awake()
    {
        StartPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            transform.position = StartPosition;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;

            var navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            if (navMeshAgent != null)
                navMeshAgent.destination = StartPosition;
        }
    }
}

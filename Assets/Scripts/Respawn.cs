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
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            if (tag == "Enemy")
            {
                var fallThroughGround = GetComponent<FallThroughGround>();
                if (fallThroughGround != null)
                    fallThroughGround.Reset();
            }

            var navMeshAgent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            if (navMeshAgent != null)
                navMeshAgent.destination = StartPosition;
        }
    }
}

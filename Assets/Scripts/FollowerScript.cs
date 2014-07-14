using UnityEngine;
using System.Collections;

public class FollowerScript : MonoBehaviour {

    public GameObject Destination;

    private NavMeshAgent _agent;
    private Animator _animator;

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(Destination.transform.position);

        if (_animator != null)
            _animator.SetFloat("Speed", _agent.velocity.magnitude / _agent.speed);
    }
}

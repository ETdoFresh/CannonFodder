using UnityEngine;
using System.Collections;

public class FollowNavMeshAgent : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 rootMotionVelocity;

    void Awake()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        _navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude);

        if (!Input.GetButton("Fire2"))
        {
            _rigidbody.transform.rotation = _navMeshAgent.transform.rotation;
            _navMeshAgent.transform.position = _rigidbody.position;
            
            var speed = Mathf.Min(_navMeshAgent.velocity.magnitude, rootMotionVelocity.magnitude);
            _rigidbody.velocity = _navMeshAgent.velocity.normalized * speed;

            Debug.DrawLine(_rigidbody.transform.position, _rigidbody.transform.position + _rigidbody.velocity + Vector3.up * .2f, Color.red);
        }
        Debug.DrawLine(_navMeshAgent.transform.position, _navMeshAgent.velocity + _navMeshAgent.transform.position + Vector3.up * .3f, Color.blue);
        Debug.DrawLine(_navMeshAgent.transform.position, _navMeshAgent.desiredVelocity + _navMeshAgent.transform.position + Vector3.up * .4f, Color.green);
    }

    void OnAnimatorMove()
    {
        rootMotionVelocity = _animator.deltaPosition / Time.deltaTime;
    }
}

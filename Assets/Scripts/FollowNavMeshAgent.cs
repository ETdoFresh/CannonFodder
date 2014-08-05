using UnityEngine;
using System.Collections;

public class FollowNavMeshAgent : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Vector3 rootMotionVelocity;

    void Awake()
    {
        _navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude);

        transform.rotation = _navMeshAgent.transform.rotation;
        _navMeshAgent.transform.rotation = new Quaternion();
        _navMeshAgent.transform.position = rigidbody.position;

        var fallingSpeed = rigidbody.velocity.y;
        var speed = Mathf.Min(_navMeshAgent.velocity.magnitude, rootMotionVelocity.magnitude);
        var speedVector = _navMeshAgent.velocity.normalized * speed;
        rigidbody.velocity = new Vector3(speedVector.x, fallingSpeed, speedVector.z);

        Debug.DrawLine(rigidbody.transform.position, rigidbody.transform.position + rigidbody.velocity + Vector3.up * .2f, Color.red);
        Debug.DrawLine(_navMeshAgent.transform.position, _navMeshAgent.velocity + _navMeshAgent.transform.position + Vector3.up * .3f, Color.blue);
        Debug.DrawLine(_navMeshAgent.transform.position, _navMeshAgent.desiredVelocity + _navMeshAgent.transform.position + Vector3.up * .4f, Color.green);
    }

    void OnAnimatorMove()
    {
        rootMotionVelocity = _animator.deltaPosition / Time.deltaTime;
    }
}
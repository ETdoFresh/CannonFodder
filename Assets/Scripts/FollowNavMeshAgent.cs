using UnityEngine;
using System.Collections;

public class FollowNavMeshAgent : MonoBehaviour
{
    public bool DebugShowRigidBodyVelocity;
    public bool DebugShowNavMeshAgentVelocity;
    public bool DebugShowNavMeshAgentDesiredVelocity;

    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Vector3 rootMotionVelocity;

    void Awake()
    {
        _navMeshAgent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude);

        transform.rotation = _navMeshAgent.transform.rotation;
        _navMeshAgent.transform.rotation = new Quaternion();
        _navMeshAgent.transform.position = GetComponent<Rigidbody>().position;

        var fallingSpeed = GetComponent<Rigidbody>().velocity.y;
        var speed = Mathf.Min(_navMeshAgent.velocity.magnitude, rootMotionVelocity.magnitude);
        var speedVector = _navMeshAgent.velocity.normalized * speed;
        GetComponent<Rigidbody>().velocity = new Vector3(speedVector.x, fallingSpeed, speedVector.z);

        if (DebugShowRigidBodyVelocity)
            Debug.DrawLine(GetComponent<Rigidbody>().transform.position, GetComponent<Rigidbody>().transform.position + GetComponent<Rigidbody>().velocity + Vector3.up * .2f, Color.red);
        if (DebugShowNavMeshAgentVelocity)
            Debug.DrawLine(_navMeshAgent.transform.position, _navMeshAgent.velocity + _navMeshAgent.transform.position + Vector3.up * .3f, Color.blue);
        if (DebugShowNavMeshAgentDesiredVelocity)
            Debug.DrawLine(_navMeshAgent.transform.position, _navMeshAgent.desiredVelocity + _navMeshAgent.transform.position + Vector3.up * .4f, Color.green);
    }

    void OnAnimatorMove()
    {
        rootMotionVelocity = _animator.deltaPosition / Time.deltaTime;
    }
}
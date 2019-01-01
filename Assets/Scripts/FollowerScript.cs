using UnityEngine;
using System.Collections;

public class FollowerScript : MonoBehaviour {

    public GameObject Destination;

    private UnityEngine.AI.NavMeshAgent _agent;

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        if (_agent == null)
            _agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(Destination.transform.position);
    }
}

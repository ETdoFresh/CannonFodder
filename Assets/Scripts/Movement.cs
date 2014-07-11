using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public GameObject Particle;
    
    private Vector3 _destination;
    private NavMeshAgent _agent;
    private Animator _animator;

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_destination);
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(Particle, hit.point, hit.transform.rotation);
                _destination = hit.point;
                _agent.SetDestination(_destination);
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            _destination = transform.position;
            _agent.SetDestination(_destination);
        }
        */

        if (_animator != null)
            _animator.SetFloat("Speed", _agent.velocity.magnitude / _agent.speed);
    }
}

using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public GameObject Particle;
    
    private Vector3 _destination;
    private NavMeshAgent _agent;
    public RAIN.Navigation.Targets.NavigationTarget NavTarget;
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
        int groundLayerMask = 1 << 9; // Ground Layer

        if (Input.GetButton("Fire1") && !Input.GetButton("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask))
            {
                Instantiate(Particle, hit.point, hit.transform.rotation);
                _destination = hit.point;
                _agent.SetDestination(_destination);
                
                if (NavTarget != null)
                    NavTarget.Position = _destination;
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

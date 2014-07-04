using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public GameObject Particle;
    public Vector3 Destination;
    public NavMeshAgent Agent;

    // Use this for initialization
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.SetDestination(Destination);
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
                Destination = hit.point;
                Agent.SetDestination(Destination);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Destination = transform.position;
            Agent.SetDestination(Destination);
        }
    }
}

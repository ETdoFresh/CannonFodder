using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float LifeTime = 1f;

    // Use this for initialization
    void Start()
    {
        rigidbody.AddRelativeForce(0, 0, 5000, ForceMode.Acceleration);
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

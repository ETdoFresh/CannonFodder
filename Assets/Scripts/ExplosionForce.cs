using UnityEngine;
using System.Collections;

public class ExplosionForce : MonoBehaviour
{
    public float ExplosionRadius = 20f;
    public float ExplosionPower = 10000f;
    public float ExplosionUpForce = 20f;

    // Use this for initialization
    void Awake()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, ExplosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit && hit.GetComponent<Rigidbody>())
            {
                hit.GetComponent<Rigidbody>().AddExplosionForce(ExplosionPower, explosionPosition, ExplosionRadius, ExplosionUpForce, ForceMode.Impulse);
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour
{
    public GameObject GrenadeExplosion;
    private bool hasHitSomething = false;

    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        if (!hasHitSomething)
        {
            hasHitSomething = true;
            Invoke("Explode", 0.5f);
        }
    }

    void Explode()
    {
        Destroy(this.gameObject);
        if (GrenadeExplosion != null)
            Instantiate(GrenadeExplosion, transform.position, transform.rotation);
    }
}

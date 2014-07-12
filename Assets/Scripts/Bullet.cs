using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float LifeTime = 1f;
    public float BulletVelocity = 100f;
    public GameObject BulletExplosion;

    // Use this for initialization
    void Start()
    {
        rigidbody.AddRelativeForce(0, 0, BulletVelocity, ForceMode.VelocityChange);
        Invoke("OnBulletContact", LifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        OnBulletContact();
    }

    void OnBulletContact()
    {
        Destroy(this.gameObject);
        if (BulletExplosion != null)
            Instantiate(BulletExplosion, transform.position, new Quaternion());
    }
}

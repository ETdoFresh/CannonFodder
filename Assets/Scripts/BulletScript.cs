using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public float LifeTime = 1f;
    public float BulletVelocity = 100f;
    public GameObject BulletExplosion;
    private float _age = 0;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, BulletVelocity, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        _age += Time.deltaTime;
        if (_age > LifeTime)
            DestroyBullet();
    }

    void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
        if (BulletExplosion != null)
            Instantiate(BulletExplosion, transform.position, new Quaternion());
    }
}

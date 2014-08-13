using UnityEngine;
using System.Collections;

public class LaunchScript : MonoBehaviour
{
    public ForceMode ForceMode = ForceMode.VelocityChange;
    public float XForceMin = 0f;
    public float XForceMax = 0f;
    public float YForceMin = 10f;
    public float YForceMax = 30f;
    public float ZForceMin = 0f;
    public float ZForceMax = 0f;
    public float XTorqueMin = 0f;
    public float XTorqueMax = 360f;
    public float YTorqueMin = 0f;
    public float YTorqueMax = 360f;
    public float ZTorqueMin = 0f;
    public float ZTorqueMax = 360f;

    private Rigidbody[] _rigidbodies;

    void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        Launch();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
            Launch();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBullet")
            Launch();
    }

    void Launch()
    {
        var xForce = Random.Range(XForceMin, XForceMax);
        var yForce = Random.Range(YForceMin, YForceMax);
        var zForce = Random.Range(ZForceMin, ZForceMax);

        var xTorque = Random.Range(XTorqueMin, XTorqueMax);
        var yTorque = Random.Range(YTorqueMin, YTorqueMax);
        var zTorque = Random.Range(ZTorqueMin, ZTorqueMax);

        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.AddForce(xForce, yForce, zForce, ForceMode);
            rigidbody.AddRelativeTorque(xTorque, yTorque, zTorque, ForceMode);
        }

        // Reset Age on Destroy Script
        var destroyScript = GetComponentInParent<DestroyScript>();
        if (destroyScript != null)
            destroyScript.DestroyAge = 0f;
    }
}

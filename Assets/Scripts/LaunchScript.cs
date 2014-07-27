using UnityEngine;
using System.Collections;

public class LaunchScript : MonoBehaviour
{
    public ForceMode ForceMode = ForceMode.VelocityChange;
    public float XForceMin = 0f;
    public float XForceMax = 0f;
    public float YForceMin = 100f;
    public float YForceMax = 100f;
    public float ZForceMin = 0f;
    public float ZForceMax = 0f;
    public float XTorqueMin = 20f;
    public float XTorqueMax = 50f;
    public float YTorqueMin = 20f;
    public float YTorqueMax = 50f;
    public float ZTorqueMin = 20f;
    public float ZTorqueMax = 50f;

    void Awake()
    {
        var yForceMin = YForceMin;
        YForceMin = YForceMax;

        Launch(); // Max Launch

        YForceMin = yForceMin;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            Launch();
            
            // Reset Age on Destroy Script
            var destroyScript = GetComponentInParent<DestroyScript>();
            if (destroyScript != null)
                destroyScript.DestroyAge = 0f;
        }
    }

    void Launch()
    {
        var xForce = Random.Range(XForceMin, XForceMax);
        var yForce = Random.Range(YForceMin, YForceMax);
        var zForce = Random.Range(ZForceMin, ZForceMax);

        var xTorque = Random.Range(XTorqueMin, XTorqueMax);
        var yTorque = Random.Range(YTorqueMin, YTorqueMax);
        var zTorque = Random.Range(ZTorqueMin, ZTorqueMax);

        rigidbody.AddForce(xForce, yForce, zForce, ForceMode);
        rigidbody.AddRelativeTorque(xTorque, yTorque, zTorque, ForceMode);
    }
}

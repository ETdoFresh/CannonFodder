using UnityEngine;
using System.Collections;

public class FallThroughGround : MonoBehaviour
{
    public float FallThroughGroundAfter = 20f;
    
    private float _fallThroughGroundTimer = 0f;
    private Collider[] _childColliders;

    public void Reset()
    {
        _fallThroughGroundTimer = 0;

        foreach (Collider childCollider in _childColliders)
            childCollider.isTrigger = false;

        // Usually if children have collider, parent collider is trigger
        if (_childColliders.Length > 1)
            GetComponent<Collider>().isTrigger = true;
    }

    void Awake()
    {
        _childColliders = GetComponentsInChildren<Collider>();
    }

    void Update()
    {
        _fallThroughGroundTimer += Time.deltaTime;

        if (_fallThroughGroundTimer > FallThroughGroundAfter)
            foreach (Collider childCollider in _childColliders)
                if (!childCollider.isTrigger)
                    childCollider.isTrigger = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBullet")
            _fallThroughGroundTimer = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
            _fallThroughGroundTimer = 0;
    }
}
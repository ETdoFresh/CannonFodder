using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject BulletObject;
    private Animator _animator;
    public float ShootRate = 0.25f;
    private float _lastShootTime = 99f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _lastShootTime += Time.deltaTime;

        if (Input.GetButton("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            float y = transform.position.y;
            if (Physics.Raycast(ray, out hit))
                transform.LookAt(new Vector3(hit.point.x, y, hit.point.z));

            if (_lastShootTime >= ShootRate)
            {
                _lastShootTime = 0;
                if (Physics.Raycast(ray, out hit))
                {
                    var offset = hit.point - transform.position;
                    offset = offset.normalized * 5;
                    Instantiate(BulletObject, transform.position + offset, Quaternion.LookRotation(hit.point - transform.position));
                }
            }
        }

        if (_animator != null)
        {
            if (Input.GetButton("Fire2"))
                _animator.SetBool("IsShooting", true);
            else
                _animator.SetBool("IsShooting", false);
        }

    }
}
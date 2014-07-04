using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject BulletObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var offset = hit.point - transform.position;
                offset = offset.normalized * 5;
                Instantiate(BulletObject, transform.position + offset, Quaternion.LookRotation(hit.point - transform.position));
            }
        }
    }
}
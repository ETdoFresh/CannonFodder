using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
            Destroy(gameObject);
    }
}

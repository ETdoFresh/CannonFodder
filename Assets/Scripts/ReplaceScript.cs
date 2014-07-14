using UnityEngine;
using System.Collections;

public class ReplaceScript : MonoBehaviour
{
    public GameObject Replacement;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            if (Replacement != null)
            {
                var position = transform.position;
                var rotation = transform.rotation;
                Instantiate(Replacement, position, rotation);
            }

            Destroy(this.gameObject);
        }
    }
}

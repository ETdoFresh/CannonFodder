using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour
{
    public GameObject DeathGameObject;
    private Object _deadGameObject;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            var position = transform.position;
            var rotation = transform.rotation;
            Destroy(gameObject);

            if (_deadGameObject == null)
                _deadGameObject = Instantiate(DeathGameObject, position, rotation);
        }
    }
}

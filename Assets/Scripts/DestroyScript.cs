using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour
{
    public float DestroyLife = 1f;
    public float DestroyAge = 0f;

    void Update()
    {
        DestroyAge += Time.deltaTime;

        if (DestroyAge >= DestroyLife)
            Destroy(gameObject);
    }
}

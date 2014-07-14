using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour
{
    public float DestroyTime = 1f;

    void Awake()
    {
        Destroy(gameObject, DestroyTime);
    }
}

using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
    public float DestroyTime = 1f;

    void Awake()
    {
        Destroy(gameObject, DestroyTime);
    }
}

using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour 
{
    public GameObject BirdObject;
    public float BirdSpawnChance = 0.002f;

    void Update()
    {
        if (Random.Range(0f, 1f) < BirdSpawnChance)
            Instantiate(BirdObject);
    }
}

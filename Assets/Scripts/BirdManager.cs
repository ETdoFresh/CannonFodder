using UnityEngine;
using System.Collections;

public class BirdManager : MonoBehaviour
{
    public enum DirectionEmum { LEFT, RIGHT };

    public DirectionEmum Direction = DirectionEmum.LEFT;
    public float XSpawn = 18;
    public float XSpeed = 0.03f;
    public float ZMin = -3.5f;
    public float ZRange = 26;
    public float Y = 10;

    private int _sign = 1;

    void Awake()
    {
        if (Direction == DirectionEmum.LEFT)
            _sign = -1;

        var xSpawn = _sign * XSpawn;

        var randomZ = Random.Range(ZMin, ZMin + ZRange);
        transform.position = new Vector3(xSpawn, Y, randomZ);
    }

    void Update()
    {
        var xSpeed = _sign * XSpeed;

        transform.position -= new Vector3(xSpeed, 0, 0);

        if (Mathf.Abs(transform.position.x) > Mathf.Abs(XSpawn))
            Destroy(gameObject);
    }
}

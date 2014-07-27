using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour
{
    public GameObject BulletObject;
    public GameObject GrenadeObject;
    public float ShootRate = 0.25f;
    public float ShootDistanceFromGround = 2f;
    public float ShootVariaion = 1f;
    public float ShootDelay = 0;
    public bool IsSwimming = false;
    public float GrenadeHeight = 50f;
    private Animator _animator;
    private float _lastShootTime = 99f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            _lastShootTime = -ShootDelay;

        _lastShootTime += Time.deltaTime;
        var isShooting = Input.GetButton("Fire2") && !IsSwimming;

        if (isShooting)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int groundLayerMask = 1 << 9;

            float y = transform.position.y;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask))
                transform.LookAt(new Vector3(hit.point.x, y, hit.point.z));

            var offset = hit.point - transform.position;
            offset = offset.normalized * 5;

            if (_lastShootTime >= ShootRate && false )
            {
                _lastShootTime = 0;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask))
                {
                    var variation = new Vector3(Random.Range(-ShootVariaion, ShootVariaion),
                           Random.Range(-ShootVariaion, ShootVariaion), Random.Range(-ShootVariaion, ShootVariaion));
                    hit.point += variation;
                    hit.point += new Vector3(0, ShootDistanceFromGround, 0);
                    GameObject bullet = Instantiate(BulletObject, transform.position + offset, Quaternion.LookRotation(hit.point - transform.position)) as GameObject;
                    
                    foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
                        Physics.IgnoreCollision(bullet.collider, player.collider);

                    foreach (GameObject playerBullet in GameObject.FindGameObjectsWithTag("PlayerBullet"))
                        Physics.IgnoreCollision(bullet.collider, playerBullet.collider);
                }
            }

            if (Input.GetButtonDown("Fire1") && GrenadeObject != null)
            {
                GameObject grenade = Instantiate(GrenadeObject, transform.position + offset, Quaternion.LookRotation(hit.point - transform.position)) as GameObject;
                var distance = (transform.position - hit.point).magnitude;
                const float MAXDISTANCE = 100f;
                var newTarget = grenade.transform.position + offset.normalized * Mathf.Min(distance, MAXDISTANCE);
                Vector3 velocity = findInitialVelocity(grenade.transform.position, newTarget, GrenadeHeight);
                grenade.rigidbody.AddForce(velocity, ForceMode.VelocityChange);

                foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
                    Physics.IgnoreCollision(grenade.collider, player.collider);

                foreach (GameObject playerBullet in GameObject.FindGameObjectsWithTag("PlayerBullet"))
                    Physics.IgnoreCollision(grenade.collider, playerBullet.collider);
            }
        }

        if (_animator != null)
        {
            if (isShooting)
                _animator.SetBool("IsShooting", true);
            else
                _animator.SetBool("IsShooting", false);
        }
    }

    /**
	 * Finds the initial velocity of a projectile given the initial positions and some offsets
	 * @param Vector3 startPosition - the starting position of the projectile
	 * @param Vector3 finalPosition - the position that we want to hit
	 * @param float maxHeightOffset (default=0.6f) - the amount we want to add to the height for short range shots. We need enough clearance so the 
	 * ball will be able to get over the rim before dropping into the target position
	 * @param float rangeOffset (default=0.11f) - the amount to add to the range to increase the chances that the ball will go through the rim
	 * @return Vector3 - the initial velocity of the ball to make it hit the target under the current gravity force.
	 */
    private Vector3 findInitialVelocity(Vector3 startPosition, Vector3 finalPosition, float maxHeightOffset = 0.6f, float rangeOffset = 0.11f)
    {
        // get our return value ready. Default to (0f, 0f, 0f)
        Vector3 newVel = new Vector3();

        // Find the direction vector without the y-component
        Vector3 direction = new Vector3(finalPosition.x, 0f, finalPosition.z) - new Vector3(startPosition.x, 0f, startPosition.z);

        // Find the distance between the two points (without the y-component)
        float range = direction.magnitude;

        // Add a little bit to the range so that the ball is aiming at hitting the back of the rim.
        // Back of the rim shots have a better chance of going in.
        // This accounts for any rounding errors that might make a shot miss (when we don't want it to).
        range += rangeOffset;

        // Find unit direction of motion without the y component
        Vector3 unitDirection = direction.normalized;

        // Find the max height
        // Start at a reasonable height above the hoop, so short range shots will have enough clearance to go in the basket
        // without hitting the front of the rim on the way up or down.
        float maxYPos = finalPosition.y + maxHeightOffset;

        // check if the range is far enough away where the shot may have flattened out enough to hit the front of the rim
        // if it has, switch the height to match a 45 degree launch angle
        if (range / 2f > maxYPos)
            maxYPos = range / 2f;

        // find the initial velocity in y direction
        newVel.y = Mathf.Sqrt(Mathf.Abs(-2.0f * Physics.gravity.y * (maxYPos - startPosition.y)));

        // find the total time by adding up the parts of the trajectory
        // time to reach the max
        float timeToMax = Mathf.Sqrt(Mathf.Abs(2.0f * (maxYPos - startPosition.y) / Physics.gravity.y));

        // time to return to y-target
        float timeToTargetY = Mathf.Sqrt(Mathf.Abs(2.0f * (maxYPos - finalPosition.y) / Physics.gravity.y));

        // add them up to find the total flight time
        float totalFlightTime = timeToMax + timeToTargetY;

        // find the magnitude of the initial velocity in the xz direction
        float horizontalVelocityMagnitude = range / totalFlightTime;

        // use the unit direction to find the x and z components of initial velocity
        newVel.x = horizontalVelocityMagnitude * unitDirection.x;
        newVel.z = horizontalVelocityMagnitude * unitDirection.z;

        return newVel;
    }
}
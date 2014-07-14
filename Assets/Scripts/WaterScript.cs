using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        var animator = other.gameObject.GetComponent<Animator>();
        if (animator)
            animator.SetBool("InWater", true);

        var shoot = other.gameObject.GetComponent<ShootScript>();
        if (shoot)
            shoot.IsSwimming = true;
    }

    void OnTriggerExit(Collider other)
    {
        var animator = other.gameObject.GetComponent<Animator>();
        if (animator)
            animator.SetBool("InWater", false);

        var shoot = other.gameObject.GetComponent<ShootScript>();
        if (shoot)
            shoot.IsSwimming = false;
    }
}

using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        x -= Input.GetAxis("Horizontal");
        y -= Input.GetAxis("Mouse ScrollWheel") * 20;
        z -= Input.GetAxis("Vertical");
        transform.position = new Vector3(x, y, z);
	}
}

using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float speed = 10f;
	public bool getsFaster = false;

	// Update is called once per frame
	void Update () {
		if (getsFaster)
			speed += Time.deltaTime/20f;
		transform.RotateAround(transform.position, Vector3.forward, speed * Time.deltaTime);
	}
}

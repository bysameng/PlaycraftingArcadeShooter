using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float speed = 10f;

	// Update is called once per frame
	void Update () {
		transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.deltaTime);
	}
}

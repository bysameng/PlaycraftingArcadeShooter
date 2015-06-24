using UnityEngine;
using System.Collections;

public class ScaleSpring : MonoBehaviour {

	public Vector3 targetScale = new Vector3(1f, 1f, 1f);
	private Vector3 velocity = Vector3.zero;
	public float strength = 9f;

	public void AddForce(Vector3 force){
		velocity += force;
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = Utilities.SimpleHarmonicMotion(transform.localScale, targetScale, ref velocity, strength, .8f);
	}
}

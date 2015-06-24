using UnityEngine;
using System.Collections;

public class PlayerScalarOnCollision : MonoBehaviour {

	public ScaleSpring scalar;


	void OnCollisionEnter2D(Collision2D other){
		float mag = other.relativeVelocity.magnitude / 10f;
		scalar.AddForce(new Vector3(mag, mag, mag));
	}

}

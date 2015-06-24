using UnityEngine;
using System.Collections;
using System;

public class ScreenShakeOnCollsion : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		CameraShake.main.Shake(other.relativeVelocity / 20f);
	}

}

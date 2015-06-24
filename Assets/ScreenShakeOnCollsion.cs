using UnityEngine;
using System.Collections;

public class ScreenShakeOnCollsion : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		CameraShake.main.Shake(other.relativeVelocity / 20f);
	}

}

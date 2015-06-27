using UnityEngine;
using System.Collections;

public class PooledParticles : MonoBehaviour {
	public static PooledParticles main;

	public ParticleSystem splat;

	void Awake(){
		main = this;
	}

	public void Splat(Vector3 position, int count){
		this.splat.transform.position = position;
		this.splat.Emit (count);
	}


}
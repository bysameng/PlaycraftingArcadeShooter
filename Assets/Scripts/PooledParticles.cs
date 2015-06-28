using UnityEngine;
using System.Collections;

public class PooledParticles : MonoBehaviour {
	public static PooledParticles main;

	public ParticleSystem splat;
	public ParticleSystem death;

	void Awake(){
		main = this;
	}

	public void Splat(Vector3 position, int count){
		this.splat.transform.position = position;
		this.splat.Emit (count);
	}

	public void Death(){
		this.transform.position = Vector3.zero;
		this.death.Play();
		Splat(Vector3.zero, 40);
	}


}
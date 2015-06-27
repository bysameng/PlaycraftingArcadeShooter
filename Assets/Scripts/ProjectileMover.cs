using UnityEngine;
using System.Collections;

public class ProjectileMover : MonoBehaviour {

	private Rigidbody rbody;

	public float speed = 10;

	private float hitForce = 200f;
	private float lifeTime = 2f;

	void Awake(){
		rbody = GetComponent<Rigidbody>();
	}


	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.forward;
		rbody.MovePosition(rbody.position + fwd * speed * Time.deltaTime);
		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0){
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision){
		this.Disable();
		GameObject g = collision.gameObject;
		if (g.tag == "Enemy"){
			Enemy e = g.GetComponent<Enemy>();
			e.OnHit(transform.forward * hitForce);
		}
	}

	public void Disable(){
		this.gameObject.SetActive(false);
	}

}

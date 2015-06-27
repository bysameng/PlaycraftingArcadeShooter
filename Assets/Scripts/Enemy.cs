using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Rigidbody rbody;

	public float score = 10f;
	public float speed = .5f;

	public SpriteRenderer render;
	public SpriteRenderer ketchuprender;


	private Vector3 target = Vector3.zero;
	private bool movingToCenter = true;

	private float deathTimer = 2f;

	void Awake(){
		rbody = GetComponent<Rigidbody>();
		this.tag = "Enemy";
	}

	// Update is called once per frame
	void Update () {
		if (movingToCenter){
			GoToCenter();
		}
	}
	void GoToCenter(){
		transform.LookAt(target);
		Vector3 fwd = transform.forward;
		rbody.MovePosition(rbody.position + fwd * speed * Time.deltaTime);
	}

	public void OnHit(Vector3 force){
		movingToCenter = false;
		rbody.AddForce(force);
		ketchuprender.enabled = true;
		Destroy();
	}

	void Destroy(){
		Destroy(this.gameObject, deathTimer);
	}

}

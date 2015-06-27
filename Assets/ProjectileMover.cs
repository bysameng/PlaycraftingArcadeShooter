using UnityEngine;
using System.Collections;

public class ProjectileMover : MonoBehaviour {

	private Rigidbody rbody;

	public float speed = 10;

	void Awake(){
		rbody = GetComponent<Rigidbody>();
	}


	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.forward;
		rbody.MovePosition(rbody.position + fwd * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log("Hit a thing!");
	}

}

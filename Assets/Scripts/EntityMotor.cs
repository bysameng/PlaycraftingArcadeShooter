using UnityEngine;
using System.Collections;

public class EntityMotor : MonoBehaviour {

	public float maxForce = 20f;
	private Vector3 currentForce = Vector3.zero;

	public float dampingRatio = .01f;

	public float acceleration = 50f;
	public float decceleration = 50f;

	public Vector3 currentInput{get; private set;}

	private Rigidbody2D rbody;


	void Awake(){
		this.rbody = GetComponent<Rigidbody2D>();
	}

	void Update () {
		DampingForce();
		UpdateAcceleration();
		ClampForce();
	}

	void FixedUpdate(){
		Move();
	}

	void UpdateAcceleration(){
		Accelerate(currentInput == Vector3.zero ? decceleration : acceleration);
	}

	void Accelerate(float delta){
		currentForce += currentInput.normalized * delta * Time.deltaTime;
		Vector3.ClampMagnitude(currentForce, maxForce);
	}

	void DampingForce(){
		currentForce *= Mathf.Pow(dampingRatio, Time.deltaTime);
	}

	void ClampForce(){
		Vector3.ClampMagnitude(currentForce, maxForce);
	}

	void Move(){
//		rbody.MovePosition(rbody.position + currentForce * Time.fixedDeltaTime);
	}


	public void GiveInput(Vector3 input){
		this.currentInput = input;
	}



}

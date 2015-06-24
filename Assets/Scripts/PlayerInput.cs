using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

//	private EntityMotor motor;

	private Rigidbody2D rbody;
	private ScaleSpring scalar;


	private float timeDown;
	private Vector2 beginPosition;
	private Vector2 lastPos;
	private bool lastTouched = false;

	private bool dragging = false;

	void Awake(){
		this.rbody = GetComponent<Rigidbody2D>();
		scalar = GetComponent<ScaleSpring>();
	}


	// Update is called once per frame
	void Update () {
		TouchLogic();
		DragTimer();
	}

	void TouchLogic(){
		Vector2 touchPos = Vector2.zero;
		Vector2 deltaPos = Vector2.zero;

//		if (Input.touchCount > 0){
//			touchPos = Input.GetTouch(0).position;
//		}


		bool touchDown = false;
//		touchDown = Input.touchCount > 0;
		touchDown = touchDown || Input.GetMouseButton(0);

		if (touchDown){
			touchPos = Input.mousePosition;
			deltaPos = touchPos - lastPos;
		}

		if (touchDown && lastTouched == true){
			rbody.AddForce(deltaPos);
			rbody.AddTorque(Random.value/10f);
		}

//		if (!dragging && touchDown){
//			OnTouchDown(touchPos);
//		}
//
//		if (dragging && !touchDown){
//			Vector2 force = OnRelease(touchPos);
//			rbody.AddForce(force);
//		}

		lastTouched = touchDown;
		lastPos = touchPos;
	}

	void DragTimer(){
		if (dragging){
			timeDown += Time.deltaTime;
		}
	}


	void OnTouchDown(Vector2 pos){
		beginPosition = pos;
		dragging = true;
	}

	Vector2 OnRelease(Vector2 pos){
		Vector2 force = pos - beginPosition;
		return force / timeDown;
	}
}

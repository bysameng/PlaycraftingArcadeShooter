using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

//	private EntityMotor motor;

	private Rigidbody rbody;
	private ScaleSpring scalar;


	private float timeDown;
	private Vector2 beginPosition;
	private Vector2 lastPos;
	private bool lastTouched = false;

	private bool dragging = false;

	public GameObject bulletPrefab;

	void Awake(){
		this.rbody = GetComponent<Rigidbody>();
		scalar = GetComponent<ScaleSpring>();
		Application.targetFrameRate = 59;
	}


	// Update is called once per frame
	void Update () {
		TouchLogic();
		if (Input.GetKeyDown(KeyCode.A)){
			ShootBullet();
		}
	}


	void TouchLogic(){
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10;
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
		this.transform.LookAt(worldPosition);
	}


	void ShootBullet(){
		Instantiate(bulletPrefab, transform.position, transform.rotation);
	}



}

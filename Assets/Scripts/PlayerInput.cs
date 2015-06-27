using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public GameObject bulletPrefab;

	private Rigidbody rbody;
	public ScaleSpring scalar;

	private float maxShootAmmo = 50f;
	private float _shootAmmo = 10f;
	private float shootAmmo{
		get{return _shootAmmo;}
		set{_shootAmmo = Mathf.Clamp(value, 0f, maxShootAmmo);}
	}
	private float regenAmmoRate = 5f;
	private float coolDown = .3f;
	private float shootDelay = .1f;

	private float fireRateTimer;
	private float cooldownTimer = 0f;

	//"constructor"
	void Awake(){
		this.rbody = GetComponent<Rigidbody>();
		Application.targetFrameRate = 59;
	}


	// Update is called once per frame
	void Update () {
		LookLogic();
		ShootLogic();
		RegenLogic();
	}


	//handles rotation input.
	void LookLogic(){
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10;
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
		Vector3 fwd = worldPosition - transform.position;
		Quaternion rot = Quaternion.LookRotation(fwd, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);
	}

	//handles shooting inputs.
	void ShootLogic(){
		if (fireRateTimer > 0){
			fireRateTimer -= Time.deltaTime;
		}
		if (Input.GetMouseButton(0)){
			if (fireRateTimer <= 0 && shootAmmo > 5f){
				ShootBulletWithCooldown();
		scalar.strength = 21f;
			}
		}
	}


	//handles regeneration
	void RegenLogic(){
		//if cooling down, do nothing.
		if (cooldownTimer > 0){
			cooldownTimer -= Time.deltaTime;
			return;
		}
		//otherwise, regenerate
		else{
			shootAmmo += regenAmmoRate * Time.deltaTime;
		}
	}


	//while shooting, set the cooldowns.
	//spawn the bullets;
	void ShootBulletWithCooldown(){
		scalar.AddForce(new Vector3(-7f, 3f, -6f));
		CameraShake.main.Shake(transform.forward);
		this.fireRateTimer = shootDelay;
		this.cooldownTimer = coolDown;
		shootAmmo -= 1f;
		ShootBullet();
	}

	//spawns the bullet.
	void ShootBullet(){
		Instantiate(bulletPrefab, transform.position, transform.rotation);
	}

	//called when an enemy hits this player.
	public void OnHit(float damage){
		shootAmmo -= damage;
		if (shootAmmo <= 0){
			Debug.Log("dead");
		}
	}



}

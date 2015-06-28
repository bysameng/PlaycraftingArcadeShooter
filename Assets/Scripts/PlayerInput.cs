using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public GameObject bulletPrefab;

	private Rigidbody rbody;
	public ScaleSpring scalar;

	public AudioSource squirtSound;

	private float maxShootAmmo = 5f;
	private float _shootAmmo = 5f;
	private float shootAmmo{
		get{return _shootAmmo;}
		set{_shootAmmo = Mathf.Clamp(value, 0f, maxShootAmmo);}
	}
	private float regenAmmoRate = 2f;
	private float coolDown = .6f;
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

		//tell this guy to look at that world position
		transform.LookAt(worldPosition, Vector3.forward);
	}

	//handles shooting inputs.
	void ShootLogic(){
		if (fireRateTimer > 0){
			fireRateTimer -= Time.deltaTime;
		}
		if (Input.GetMouseButton(0)){
			if (fireRateTimer <= 0 && shootAmmo > 0){
				TryShoot();
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

	void TryShoot(){
		scalar.AddForce(new Vector3(-7f, 3f, -6f));
		if (shootAmmo > 0){
			ShootBulletWithCooldown();
		}
	}

	//while shooting, set the cooldowns.
	//spawn the bullets;
	void ShootBulletWithCooldown(){
		CameraShake.main.Shake(transform.forward);
		this.fireRateTimer = shootDelay;
		this.cooldownTimer = coolDown;
		shootAmmo -= 1f;
		ShootBullet();
		squirtSound.pitch = Random.Range(.8f, 1.2f);
		squirtSound.Play ();
	}

	//spawns the bullet.
	void ShootBullet(){
		//instantiate the bullet
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

		//rotate a bit for some variation
		bullet.transform.RotateAround(bullet.transform.position, Vector3.forward, Random.Range(-2f, 2f));
	}

	//called when an enemy hits this player.
	public void OnHit(float damage){
	}

	void OnCollisionEnter(Collision other){
		KillPlayer();
		Director.main.StartGameOver();
	}

	void KillPlayer(){
		PooledParticles.main.Death();
		CameraShake.main.Shake (.3f, .21f);
		Destroy(this.gameObject);
	}



}

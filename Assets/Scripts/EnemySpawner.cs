using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	private int _phase = 2;
	public int phase{
		get{return _phase;}
		set{_phase = Mathf.Clamp(value, 0, enemyPrefabs.Length);}
	}

	public GameObject[] enemyPrefabs;
	public float spawnDelay = .5f;
	private float spawnTimer = 0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", 0f, 2f);
	}
	
	// Update is called once per frame
	void Update (){
		SpawnLogic();
	}

	void SpawnLogic(){
		if (spawnTimer > 0){
			spawnTimer -= Time.deltaTime;
		}
		if (spawnTimer <= 0){
			spawnTimer = spawnDelay;
		}
	}

	GameObject GetEnemy(){
		return enemyPrefabs[Random.Range(0, phase)];
	}
	
	void SpawnEnemy (){
		float randomAngle = Random.Range(0f, 360f);
		Vector3 spawnPos = new Vector3(6f, 0f, 0f);
		GameObject enemy = Instantiate(GetEnemy(), spawnPos, Quaternion.identity) as GameObject;
		enemy.transform.RotateAround(Vector3.zero, Vector3.forward, randomAngle);
	}
}

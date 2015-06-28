using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	private float _phase = 0;
	public float phase{
		get{return _phase;}
		set{_phase = Mathf.Clamp(value, 0, enemyPrefabs.Length);}
	}

	public GameObject[] enemyPrefabs;
	public float spawnDelay = .1f;
	private float spawnTimer = 0f;


	// Update is called once per frame
	void Update (){
		spawnDelay -= Time.deltaTime / 100f;
		phase += Time.deltaTime / 10f;
		SpawnLogic();
	}

	void SpawnLogic(){
		if (spawnTimer > 0){
			spawnTimer -= Time.deltaTime;
		}
		if (spawnTimer <= 0){
			spawnTimer = spawnDelay;
			SpawnEnemy();
		}
	}

	GameObject GetEnemy(){
		return enemyPrefabs[Random.Range(0, Mathf.FloorToInt(phase))];
	}
	
	void SpawnEnemy (){
		float randomAngle = Random.Range(0f, 360f);
		Vector3 spawnPos = new Vector3(8f, 0f, 0f);
		GameObject enemy = Instantiate(GetEnemy(), spawnPos, Quaternion.identity) as GameObject;
		enemy.transform.RotateAround(Vector3.zero, Vector3.forward, randomAngle);
	}
}

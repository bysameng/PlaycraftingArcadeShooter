using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemy;
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
	
	void SpawnEnemy (){
		Vector3 randomVec = Random.onUnitSphere;
		randomVec.z = 0;
		var _enemy = Instantiate(enemy, transform.position + randomVec * 8f, Quaternion.identity) as GameObject;
//		int rand = Random.Range (0, 2);
//		
//		if (rand == 0)
//			_enemy.transform.eulerAngles = new Vector3 (0, 0, 90);
	}
}

using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {


	float timer = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0){
			timer -= Time.deltaTime;
			return;
		}
		if (Input.anyKeyDown){
			Application.LoadLevel(0);
		}
	}
}

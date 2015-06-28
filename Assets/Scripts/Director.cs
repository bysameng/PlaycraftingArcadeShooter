using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Director : MonoBehaviour {

	public static Director main;

	public int currentScore;
	public Text scoreText;
	public GameObject gameOverCanvas;

	public AudioSource backgroundMusic;
	public AudioClip endMusic;
	public AudioClip gameOverSound;


	private bool isGameOver;

	void Awake(){
		main = this;
		isGameOver = false;
		currentScore = 0;
	}

	void Update(){
		if (isGameOver && Input.anyKeyDown){
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void AddScore(int score = 1){
		this.currentScore += score;
	}

	public void StartGameOver(){
		Invoke("GameOver", 2f);
		AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
	}

	void GameOver(){
//		backgroundMusic.Stop();
		backgroundMusic.clip = endMusic;
		backgroundMusic.Play();
		scoreText.text = "you squirted on "  + currentScore + " things.";
		isGameOver = true;
		CameraShake.main.targetFov = 1f;
		gameOverCanvas.SetActive(true);
	}

}

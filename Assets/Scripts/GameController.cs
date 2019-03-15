using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Helper Class for Score Management:
class ScoreManager {
	public ScoreManager()
	{
		score = 0;
	}
	public void AddScore(int incremental = 10) {
		score += incremental;
	}
	public int GetScore() {
		return score;
	}

	private static int score;
}

public class GameController : MonoBehaviour {
	//Hazardrous properties:
	public GameObject hazardObject;
	public int hazardsPerWave;
	public Vector3 spawnReference;
	public float startTimer;
	public float spawnTimer;
	public float waveBreak;
	bool gameOver;

	//UI Properties:
	public Text scoreText;
	
	//Score:
	ScoreManager scoreManager;

	//Audio
	public AudioSource backgroundMusic;
	public AudioSource gameOverMusic;

	//Initialize local properties:
	public GameController()
	{}
	// Use this for initialization
	void Start () {
		scoreManager = new ScoreManager();
		gameOver = false;
		PrintScore();
		StartCoroutine(SpawnWaves());
	}

	//Co-routine to spawn endless waves:
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(startTimer);
		//Keep spawning from start to finish:
		while (!gameOver)
		{
			for (int i = hazardsPerWave; i > 0; --i)
			{
				SpawnSingle();
				//Between Hazards:
				yield return new WaitForSeconds(spawnTimer);
			}
			//Between waves:
			yield return new WaitForSeconds(waveBreak);
		}
	}
	void SpawnSingle() {
		Vector3 spawnPosition = new Vector3 (
					Random.Range(-spawnReference.x, spawnReference.x),
					spawnReference.y,
					spawnReference.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazardObject, spawnPosition, spawnRotation);
	}

	public void UpdateScore()
	{
		scoreManager.AddScore();
		PrintScore();
	}
	void PrintScore()
	{
		int currentScore = scoreManager.GetScore();
		scoreText.text = "Score: " + currentScore;
	}

	public void GameOver()
	{
		//Stop spawning and mute music:
		gameOver = true;
		backgroundMusic.Stop();
		gameOverMusic.Play();
	}
	public bool CheckGameOver()
	{
		return gameOver;
	}
}

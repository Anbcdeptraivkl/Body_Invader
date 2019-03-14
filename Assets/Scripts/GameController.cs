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
	bool isSpawning;

	//UI Properties:
	public Text scoreText;
	
	//Score:
	ScoreManager scoreManager;

	public GameController()
	{
		KeepSpawningWaves(true);
		scoreManager = new ScoreManager();
	}
	// Use this for initialization
	void Start () {
		PrintScore();
		StartCoroutine(SpawnWaves());
	}
	//Co-routine to spawn endless waves:
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(startTimer);
		//Keep spawning from start to finish:
		while (isSpawning)
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
	void KeepSpawningWaves(bool spawning) {
		isSpawning = spawning;
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
}

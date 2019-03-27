using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Helper Class for Score Management:
public class ScoreManager {
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

	public int GetHighScore()
	{
		return PlayerPrefs.GetInt("highScore", 0);
	}

	//High Score Register with boolean check:
	public bool SetHighScore()
	{
		if (score > PlayerPrefs.GetInt("highScore", 0))
		{
			PlayerPrefs.SetInt("highScore", score);
			return true;
		}
		else 
			return false;
	}

	private int score;
}

public class GameController : MonoBehaviour {
	//Hazardrous properties:
	public GameObject[] hazardObjectsList;
	public int hazardsPerWave;
	public Vector3 spawnReference;
	public float startTimer;
	public float spawnTimer;
	public float waveBreak;
	bool gameOver;
	bool newHighScoreAchieved;

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
		newHighScoreAchieved = false;
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
		Instantiate (
			hazardObjectsList[Random.Range(0, hazardObjectsList.Length)], 
			spawnPosition, 
			spawnRotation);
	}

	public void UpdateScore(int scoreValue = 10)
	{
		scoreManager.AddScore(scoreValue);
		PrintScore();
	}
	void PrintScore()
	{
		int currentScore = scoreManager.GetScore();
		scoreText.text = "Score: " + currentScore;
	}

	public void GameOver()
	{
		HighScoreUpdate();
		//Stop spawning and mute music:
		gameOver = true;
		backgroundMusic.Stop();
		gameOverMusic.Play();
	}

	void HighScoreUpdate()
	{
		//Update the High score value
		//Check boolean whether the player got high score:
		newHighScoreAchieved = scoreManager.SetHighScore();
		//Print high score to console:
		Debug.Log(PlayerPrefs.GetInt("highScore"));
	}
	public bool CheckGameOver()
	{
		return gameOver;
	}

	public bool CheckNewHighScore()
	{
		return newHighScoreAchieved;
	}
}

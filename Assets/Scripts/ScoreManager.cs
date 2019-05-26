using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    bool newHighScoreAchieved;

    public Text scoreText;

    void Start () {
        score = 0;
        newHighScoreAchieved = false;
		PrintScore();
    }
    
	void AddScore(int incremental = 10) {
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

    public void UpdateScore(int scoreValue = 10)
	{
		AddScore(scoreValue);
		PrintScore();
	}
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
	public bool CheckIfNewHighScore()
	{
		return newHighScoreAchieved;
	}
    public void HighScoreUpdate()
	{
		//Update the High score value
		//Check boolean whether the player got high score:
		newHighScoreAchieved = SetHighScore();
		//Print high score to console:
		Debug.Log(PlayerPrefs.GetInt("highScore"));
	}

    void PrintScore()
	{
		scoreText.text = "Score: " + score;
	}
    // **Working on Breaking the GameController into Components:
    //  - Now building the score manager and Game Over classes.
}

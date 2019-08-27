using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool gameOver;

    ScoreManager scoreManager;
    MoneyManager moneyManager;

    public AudioSource backgroundMusic;
    public AudioSource gameOverMusic;

    public GameObject playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) 
		{
			scoreManager = gameControllerObject.GetComponent<ScoreManager>();
            moneyManager = gameControllerObject.GetComponent<MoneyManager>();	
		}
        else
        {
            Debug.Log("Failed to load <GameController> component.");
        }
    }

    public void Over()
	{
		//Stop spawning and mute music:
		gameOver = true;
		backgroundMusic.Stop();
		gameOverMusic.Play();

        // Update Player Prefs:
        scoreManager.HighScoreUpdate();
        moneyManager.UpdateMoney();

        // Hide the player status panel:
        playerStatus.SetActive(false);
	}

    public bool CheckGameOver () {
        return gameOver;
    }
}

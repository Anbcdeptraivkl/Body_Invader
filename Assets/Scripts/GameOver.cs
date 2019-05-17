using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool gameOver;

    ScoreManager scoreManager;
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
			
		}
        else
        {
            Debug.Log("Failed to load <GameController> component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Over()
	{
		//Stop spawning and mute music:
        scoreManager.HighScoreUpdate();
		gameOver = true;
		backgroundMusic.Stop();
		gameOverMusic.Play();

        // Hide the player status panel:
        playerStatus.SetActive(false);
	}

    public bool CheckGameOver () {
        return gameOver;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool gameOver;
    MoneyManager moneyManager;
    GameObject background;

    public AudioSource backgroundMusic;
    public AudioSource gameOverMusic;

    public GameObject playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        background = GameObject.FindWithTag("Background");
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) 
		{
            moneyManager = gameControllerObject.GetComponent<MoneyManager>();	
		}
    }

    public void Over()
	{
		//Stop spawning and mute music:
		gameOver = true;
		backgroundMusic.Stop();
        // No Scrolling
        background.GetComponent<BackgroundScrolling>().enabled  = false;
		gameOverMusic.Play();

        // Update Player Prefs:
        moneyManager.UpdateMoney();

        // Hide the player status panel:
        playerStatus.SetActive(false);
	}

    public bool CheckGameOver () {
        return gameOver;
    }
}

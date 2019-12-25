using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Complete the Level by defeating all enemies:
// Act as a Controller Component for Game Controller Game Object:
public class LevelComplete : MonoBehaviour
{
    // Properties:
    public GameObject completePanel;
    public GameObject playerCanvas;

    public Text scoreText;
    public Text coinText;
    public int levelIndex = 1;

    // References:
    LevelSpawner levelSpawner;
    MoneyManager moneyManager;
    ScoreManager scoreManager;

    void Start() {
        levelSpawner = gameObject.GetComponent<LevelSpawner>();
        moneyManager = gameObject.GetComponent<MoneyManager>();
        scoreManager = gameObject.GetComponent<ScoreManager>();
    }

    void Update() {
        if (levelSpawner.LevelCompleteCheck() && EnemyCount.Wiped()) {
            // Delay so the player has enough time to collect the last coins:
            Invoke("FinishLevel", 2.5f);
            // Stop updating when the level is finished:
            enabled = false;
        }
    }

    void FinishLevel() {
        completePanel.SetActive(true);
        playerCanvas.SetActive(false);
        // Intuitive Effects:
        PlayEffects();
        // Print Results:
        scoreText.text = "Score: " + scoreManager.GetScore() + " (" + scoreManager.GetHighScore() + ")";
        coinText.text = "Coin: " + MoneyManager.GetTotalMoney() + " + " + moneyManager.GetStageMoney();
        // Updating Preferences:
        scoreManager.HighScoreUpdate();
        moneyManager.UpdateMoney();
        // If completed a new levels, update the Level COmplettion Pref
        if (levelIndex > PlayerPrefs.GetInt("LevelsDone", 0))
            PlayerPrefs.SetInt("LevelsDone", levelIndex);
        Debug.Log("Level Completed!");
    }

    void PlayEffects() {

    }

}

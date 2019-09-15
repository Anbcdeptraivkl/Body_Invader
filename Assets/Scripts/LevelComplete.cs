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

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text coinText;

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
            Invoke("FinishLevel", 5);

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

        Debug.Log("Level Completed!");
    }

    void PlayEffects() {

    }

}

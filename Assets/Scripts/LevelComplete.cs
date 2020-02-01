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
    CompleteLine completeLineBehaviour;
    MoneyManager moneyManager;
    ScoreManager scoreManager;

    void Start() {
        GameObject comLine = GameObject.FindWithTag("GoalLine");
        if (comLine) {
            completeLineBehaviour = comLine.GetComponent<CompleteLine>();
        } else 
            Debug.Log("No Goal Line Found!");
        moneyManager = gameObject.GetComponent<MoneyManager>();
        scoreManager = gameObject.GetComponent<ScoreManager>();
    }

    void Update() {
        if (completeLineBehaviour.CheckLevelComplete() && EnemyCount.Wiped()) {
            // Delay so the player has enough time to collect the last coins:
            Invoke("FinishLevel", 2f);
            // Stop updating when the level is finished:
            enabled = false;
        }
    }

    void FinishLevel() {
        // UIs
        ActivateUIs();
        // Intuitive Effects:
        PlayEffects();
        // Print level's results on screen
        Results();
        // Prefs Updating + Reseting for next Stage
        UpdatePrefs();
        ResetUsingItemsPrefs();
        Debug.Log("Level Completed!");
    }

    void ActivateUIs() {
        completePanel.SetActive(true);
        playerCanvas.SetActive(false);
    }

    void Results() {
         // Print Results:
        scoreText.text = "Score: " + scoreManager.GetScore() + " (" + scoreManager.GetHighScore() + ")";
        coinText.text = "Coin: " + MoneyManager.GetTotalMoney() + " + " + moneyManager.GetStageMoney();
        
    }

    void UpdatePrefs() {
        // Updating Preferences:
        scoreManager.HighScoreUpdate();
        moneyManager.UpdateMoney();
    }

    // Reset Preparation Data after completing levels
    void ResetUsingItemsPrefs() {
        PlayerPrefs.SetInt("UsingWeapon", 0);
        PlayerPrefs.SetInt("UsingEquip", 0);
        PlayerPrefs.SetInt("UsingConsume", 0);
         // If completed a new levels, update the Level COmplettion Pref
        if (levelIndex > PlayerPrefs.GetInt("LevelsDone", 0))
            PlayerPrefs.SetInt("LevelsDone", levelIndex);
    }

    void PlayEffects() {

    }

}

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

    // Sessions
    // Complete the game Flag
    static bool win;
    // References:
    MoneyManager moneyManager;

    void Start() {
        win = false;
        moneyManager = gameObject.GetComponent<MoneyManager>();
    }

    void Update() {
        if (win && EnemyCount.Wiped()) {
            // Delay so the player has enough time to collect the last coins:
            Invoke("FinishLevel", 2f);
            // Stop updating when the level is finished:
            enabled = false;
        }
    }

    public static void Win() {
        win = true;
    }

    void FinishLevel() {
        Debug.Log("Level Completed!");
        // UIs
        ActivateUIs();
        // Intuitive Effects:
        PlayEffects();
        // Prefs Updating + Reseting for next Stage
        UpdatePrefs();
    }

    void ActivateUIs() {
        playerCanvas.SetActive(false);
        completePanel.SetActive(true);
        Results();
    }

    void Results() {
        // Print level's results on screen
        coinText.text = "Coin: " + MoneyManager.GetTotalMoney() + " + " + moneyManager.GetStageMoney();
    }

    void UpdatePrefs() {
        // Updating Preferences:
        moneyManager.UpdateMoney();
    }

    void PlayEffects() {

    }

}

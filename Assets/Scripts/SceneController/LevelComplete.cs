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
    Player player;
    Animator playerAnimator;
    MoneyManager moneyManager;

    void Start() {
        win = false;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        moneyManager = gameObject.GetComponent<MoneyManager>();
    }

    void Update() {
        if (win && EnemyCount.Wiped()) {
            StartCoroutine(FinishLevel());
            // Stop updating when the level is finished:
            enabled = false;
        }
    }

    public static void Win() {
        win = true;
    }

    // Coroutine for Finishing the Level
    IEnumerator FinishLevel() {
        // Delay so the player has enough time to collect the last coins + for the Sequence of SPecial Effects finished playing
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Level Completed!");
        // Player Fly Away
        player.NoMoreControls();
        playerAnimator.SetTrigger("Win");
        yield return new WaitForSeconds(1f);
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

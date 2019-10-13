using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenuController: MonoBehaviour {
    public GameObject[] tabs;

    public Text shopCoinText;

    [SerializeField]
    float incrementTiming = 0.01f;

    int currentMoney;

    void Start() {
        ActivateTab();

        // Only use in Shop, still available in other scenes, though:
        currentMoney = PlayerPrefs.GetInt("Money", 0);
    }

    void Update() {
        shopCoinText.text = currentMoney.ToString();
    }

    public void ActivateTab(int index = 0) {
        // Disable all, then re-activate only the current one
        foreach( GameObject tab in tabs) {
            tab.SetActive(false);
        }

        tabs[index].SetActive(true);
    }

    // Return to Menu after Unloading the Additive Shop Scene
    public void BackToMainMenu() {
        SceneManager.UnloadSceneAsync("Shop");
    }

    public void SpendMoney(int amount) {
        // Valid amount:
        if (currentMoney > amount) {
            StartCoroutine(DepleteMoneyGradually(amount));
            Debug.Log("Spent " + amount + " Coins!");
        } else {
            Debug.Log("Insufficient amount of money");
        }
    }

    // Increase money for Debugging and Testing purpose
    public void Debug_GetMoney(int amount) {
        currentMoney += amount;
         // Re-set the Money Bank:
        PlayerPrefs.SetInt("Money", currentMoney);
    }

    IEnumerator DepleteMoneyGradually(int amount) {
        int targetCount = currentMoney - amount;
        while (currentMoney > targetCount) {
            // Deplete with Increment
            currentMoney--;

            yield return new WaitForSeconds(incrementTiming);
        }

        // Re-set the Money Bank:
        PlayerPrefs.SetInt("Money", currentMoney);
    }
}
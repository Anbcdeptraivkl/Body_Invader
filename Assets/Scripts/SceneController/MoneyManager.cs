using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Control the Money Properties and Appearances:
public class MoneyManager : MonoBehaviour
{
    // The Text Displaying the amount of money in current stage:
    public Text moneyText;

    int stageMoneyAmount;
    int totalMoney;


    // Start is called before the first frame update
    void Awake() {
        totalMoney = PlayerPrefs.GetInt("Money", 0);
    }

    void Start()
    {
        // Reset the Stage amount on lv beginning:
        stageMoneyAmount = 0;
    }

    void Update() {
        // Display the Stage money in the MoneyText:
        if (stageMoneyAmount >= 0)
            moneyText.text = stageMoneyAmount.ToString();
    }

    // void OnApplicationQuit() {
    //     UpdateMoney();
    // }


    public void IncreaseCurrent(int amount = 1) {
        stageMoneyAmount += amount;
    }

    public void DecreaseCurrent(int amount) {
        if (stageMoneyAmount >= amount)
            stageMoneyAmount -= amount;
    }

    // For Testing only!!!
    public static void ResetMoney() {
        PlayerPrefs.SetInt("Money", 0);
        Debug.Log("Money Reset to 0!");
    }

    public int GetStageMoney() {
        return stageMoneyAmount;
    }

    public static int GetTotalMoney() {
        int total = PlayerPrefs.GetInt("Money", 0);
        if (total < 0) {
            return 0;
        }

        return total;
    }

    // Call on Stage over + Game Over (won't save preemptively):
    public void UpdateMoney() {
        // Update:
        int updated = PlayerPrefs.GetInt("Money", 0) + stageMoneyAmount;
        // Set and Save:
        PlayerPrefs.SetInt("Money", updated);
    }
}

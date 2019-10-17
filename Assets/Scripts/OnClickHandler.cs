using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* For the Main Menu Panel: All the Button On click Functions that work in the Main Menu can be found here */
public class OnClickHandler : MonoBehaviour
{
    public void StartPlayingGame() {
        SceneManager.LoadScene("Level0");
    }

    public void QuitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //highscore reseter:
    public void ResetHighScore() {
		PlayerPrefs.SetInt("highScore", 0);
	}

    public void Debug_MenuMoneyReset() {
        MoneyManager.ResetMoney();
        Debug.Log("Money Reset!");
    }

    public void Debug_MenuLogMoneyTotal() {
        Debug.Log("Money: " + MoneyManager.GetTotalMoney());
    }

    public void Debug_CheckBoughtPref(int itemValue) {
        ItemID item = (ItemID)itemValue;
        string itemName = item.ToString();
        string prefName = itemName.ToString() + "Bought";

        int boughtPref = PlayerPrefs.GetInt(prefName, 0);

        if (boughtPref == 1) {
            Debug.Log(" is Bought");
        } else if (boughtPref == 0) {
            Debug.Log(" isn't Bought yet");
        }
    }
}

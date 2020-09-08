using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* For the Main Menu Panel: All the Button On click Functions that work in the Main Menu can be found here */
public class OnClickHandler : MonoBehaviour
{
    public void QuitGame() {
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
    }

    public void Debug_MenuLogMoneyTotal() {
        Debug.Log("Money: " + MoneyManager.GetTotalMoney());
    }
}

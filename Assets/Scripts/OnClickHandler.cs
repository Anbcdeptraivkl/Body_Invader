using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* All the Button On click Functions that work in the Main Menu can be found here */
public class OnClickHandler : MonoBehaviour
{
    public void StartPlayingGame()
    {
        SceneManager.LoadScene("Level0");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //highscore reseter:
    public void ResetHighScore()
	{
		PlayerPrefs.SetInt("highScore", 0);
	}

    public void MenuMoneyReset() {
        MoneyManager.ResetMoney();
    }

    public void MenuLogMoneyTotal() {
        Debug.Log(MoneyManager.GetTotalMoney());
    }
}

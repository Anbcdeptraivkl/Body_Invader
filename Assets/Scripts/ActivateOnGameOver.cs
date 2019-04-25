using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***Controller for Game over Text Animation State:***/
public class ActivateOnGameOver : MonoBehaviour
{
    //Script References:
    private GameOver gameOverController;

    private ScoreManager scoreManager;
    Animator gameOverAnimator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameOverController = gameControllerObject.GetComponent<GameOver>();
            scoreManager = gameControllerObject.GetComponent<ScoreManager>();
        }
        else
        {
            Debug.Log("Failed to load <GameController> script component.");
        }
        gameOverAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking for update to Play animations:
        gameOverAnimator.SetBool("GameOver", gameOverController.CheckGameOver());
        gameOverAnimator.SetBool("GotHighScore", scoreManager.CheckIfNewHighScore());
    }
}

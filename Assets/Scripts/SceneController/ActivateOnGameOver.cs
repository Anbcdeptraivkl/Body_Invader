using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***Controller for Game over Text Animation State:***/
public class ActivateOnGameOver : MonoBehaviour
{
    //Script References:
    private GameOver gameOverController;
    Animator gameOverAnimator;
    // Start is called before the first frame update

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameOverController = gameControllerObject.GetComponent<GameOver>();
        }
        gameOverAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking for update to Play animations:
        gameOverAnimator.SetBool("GameOver", gameOverController.CheckGameOver());
    }
}

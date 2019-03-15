using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnGameOver : MonoBehaviour
{
    //Script References:
    public GameController gameController;
    Animator gameOverAnimator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
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
        gameOverAnimator.SetBool("GameOver", gameController.CheckGameOver());
    }
}

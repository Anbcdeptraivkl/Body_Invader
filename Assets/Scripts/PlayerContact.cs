using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Destroy Player on Contact */
public class PlayerContact : MonoBehaviour
{
    public GameObject playerExplosion;
    GameOver gameOverController;
    // Start is called before the first frame update
    void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			
			gameOverController = gameControllerObject.GetComponent<GameOver>();
		}
			else
			{
				Debug.Log("Failed to load <GameController> script component.");
			}
	}

    void OnTriggerEnter2D (Collider2D other)
	{
		//Destroy Player:
		if (other.gameObject.tag != "Boundary" )
		{
			if (other.gameObject.tag == "Player")
            {
                playerExplosion = Instantiate(
                    playerExplosion, 
                    other.transform.position, 
                    other.transform.rotation) as GameObject;

                Destroy(other.gameObject);
                Destroy(playerExplosion, 2.0f);
                //Game over:
                gameOverController.Over();
            }
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*When the enemy's bolt hit the player, esplode */
public class EnemyShotPlayer : MonoBehaviour
{
    public GameObject playerExplosion;
    //Script References:
	private GameController gameController;

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
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerExplosion = Instantiate(
                playerExplosion, 
                other.transform.position,
                other.transform.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(playerExplosion, 2.0f);
            Destroy(gameObject);
            //Game over since the player has been destroyed:
            gameController.GameOver();
        }
    }
}

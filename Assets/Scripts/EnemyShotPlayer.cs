using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*When the enemy's bolt hit the player, deplete HP (the deaths and explosions are calculatred in the Player HP Manager)*/
public class EnemyShotPlayer : MonoBehaviour
{
 
    

    private PlayerHPManager playerHp;

	void Start()
	{
        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj) {

            playerHp = playerObj.GetComponent<PlayerHPManager>();
        }
        else {
            Debug.Log("Player not found or destroyed.");
        }
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Check for player Invincible frames before acting:
            if (!playerHp.CheckInvin()) {

                playerHp.DecreaseHp();

            }
            // Decreasing Player HP and Play effects:

            Destroy(gameObject);

        }
    }
}

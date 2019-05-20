﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*When Contact with player, Deplete player HP and Destroy Self (accompany with Explosions)*/
public class EnemyPlayerContact : MonoBehaviour
{
    public GameObject selfExplosion;

	PlayerHPManager playerHp;

	
    // Start is called before the first frame update
    void Start()
	{
		GameObject playerObj = GameObject.FindWithTag("Player");

		if (playerObj) {	
			playerHp = playerObj.GetComponent<PlayerHPManager>();
		} else {
			Debug.Log("Player not found");
		}
	}

    void OnTriggerEnter2D (Collider2D other)
	{
		//Destroy Player:
		if (other.gameObject.tag != "Boundary" )
		{
			if (other.gameObject.tag == "Player")
            {
				//Deplete player HP if isn't currently in Invincible frames:
				if (!playerHp.CheckInvin()) {

					playerHp.DecreaseHp();

				}
				// Deplete Player HP:

				// Play the explosion:
                selfExplosion = Instantiate(
                    selfExplosion, 
                    transform.position, 
                    transform.rotation) as GameObject;

                Destroy(selfExplosion, 2.0f);

				//Destroy the enemiy contacting with player:
                Destroy(gameObject);
            }
		}
	}
}
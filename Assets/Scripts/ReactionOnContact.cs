using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionOnContact : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject shotExplosion;

	//References:
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

	void OnTriggerEnter2D (Collider2D other)
	{
		//Destroy and adding point on Contact (exclude the bound box):
		if (other.gameObject.tag != "Boundary" )
		{
			if (other.gameObject.tag != "Meteor")
			{
				DestroyOnContact(other);
			}
			
		}
	}

	private void DestroyOnContact(Collider2D other)
	{
		//Destroy the effects after played:
		if (other.gameObject.tag == "Player")
		{
			DestroyPlayerWithExplosion(other);
			Destroy(playerExplosion, 2.0f);
		}
		else //Destroy if get shot:
			if (other.gameObject.tag == "Shot")
			{
				DestroyOnShot(other);
				Destroy(shotExplosion, 1.0f);
			}
		gameController.UpdateScore();
		//Destroy meteor:
		Destroy(gameObject);
	}

	private void DestroyPlayerWithExplosion(Collider2D player)
	{
		ClonePlayerExplosion(player);
		//Destroy after played:
		Destroy(player.gameObject);
	}
	private void ClonePlayerExplosion (Collider2D player)
	{
		playerExplosion = Instantiate(
			playerExplosion, 
			player.transform.position, 
			player.transform.rotation) as GameObject;
	}

	private void DestroyOnShot(Collider2D shot)
	{
		CloneShotExplosion();
		Destroy(shot.gameObject);
	}
	private void CloneShotExplosion()
	{
		shotExplosion = Instantiate(
			shotExplosion, 
			transform.position, 
			transform.rotation) as GameObject;
	}
}

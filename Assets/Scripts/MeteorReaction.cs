using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorReaction : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject shotExplosion;

	void OnTriggerEnter2D (Collider2D other)
	{
		//Destroy on Contact (exclude the bound box):
		if (other.gameObject.tag != "Boundary")
		{
			DestroyOnContact(other);
		}
	}

	private void DestroyOnContact(Collider2D other)
	{
		//Destroy the colldiding objects:
		if (other.gameObject.tag == "Player")
		{
			DestroyPlayerWithExplosion(other);
			Destroy(playerExplosion, 1.0f);
		}
		else //Destroy if get shot:
			if (other.gameObject.tag == "Shot")
			{
				DestroyOnShot(other);
				Destroy(shotExplosion, 1.0f);
			}
		//Destroy meteor:
		Destroy(gameObject);
	}

	private void DestroyPlayerWithExplosion(Collider2D player)
	{
		ClonePlayerExplosion(player);
		//Disable the player:
		//player.gameObject.SetActive(false);
		//Play the animation:
		var explosionParticle = playerExplosion.GetComponent<ParticleSystem>();
		//Destroy object and animation after played:
		explosionParticle.Play();
		Destroy(player.gameObject);
	}

	private void DestroyOnShot(Collider2D shot)
	{
		CloneShotExplosion();
		Destroy(shot.gameObject);
	}

	//Clone a copy of the Player Explosion
	private void ClonePlayerExplosion (Collider2D player)
	{
		playerExplosion = Instantiate(
			playerExplosion, 
			player.transform.position, 
			player.transform.rotation) as GameObject;
	}

	private void CloneShotExplosion()
	{
		shotExplosion = Instantiate(
			shotExplosion, 
			transform.position, 
			transform.rotation) as GameObject;
	}
}

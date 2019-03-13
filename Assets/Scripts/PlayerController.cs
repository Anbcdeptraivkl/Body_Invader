using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundary{
	public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour {
	//Movement attributes:
	public float moveSpeed;
	public float tiltRate;
	public Boundary bounds;
	//Sooting attributes:
	public GameObject shot;
	public Transform shotSpawnPoint;
	public float fireRate = 0.5f;
	
	float timeTilNextFire = 0.0f;
	// Use this for initialization
	Rigidbody2D rgbd2D;
	AudioSource sfx;
	void Start () {
		rgbd2D = gameObject.GetComponent<Rigidbody2D>();
		sfx = GetComponent<AudioSource>();
	}

	
	void Update()
	{
		ShootWithSound();
	}
	void ShootWithSound()
	{
		if (Input.GetButton("Fire1") && Time.time > timeTilNextFire)
		{
			timeTilNextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawnPoint.position, shotSpawnPoint.rotation);
			//Play sfx:
			sfx.Play();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MovePlayer();
		ClampToBound();
		RotatePlayerOnMoving();
	}

	void MovePlayer()
	{
		float horiMove = Input.GetAxis("Horizontal");
		float vertiMove = Input.GetAxis("Vertical");
		Vector2 movementVector = new Vector2(horiMove, vertiMove);
		rgbd2D.velocity = movementVector * moveSpeed;
	}
	void ClampToBound()
	{
		rgbd2D.position = new Vector2(
			Mathf.Clamp(rgbd2D.position.x, bounds.xMin, bounds.xMax),
			Mathf.Clamp(rgbd2D.position.y, bounds.yMin, bounds.yMax)
		);
	}
	void RotatePlayerOnMoving()
	{
		rgbd2D.rotation = rgbd2D.velocity.x * tiltRate;
	}
}

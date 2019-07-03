using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundary{
	public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour {
	//Movement attributes:
	public float moveSpeed = 2.0f;
	public float moveRate = 0.5f;

	public float tiltRate;
	public Boundary bounds;

	Rigidbody2D rgbd2D;



	void Start () {
		rgbd2D = gameObject.GetComponent<Rigidbody2D>();

		
	}

	// Update is called once per frame
	// Update after all the Updates and Animations has finished:
	void LateUpdate () {
		MovePlayer();
		ClampToBound();
	}

	// Move the player with Axis Movement:
	void MovePlayer()
	{
		float horiMove = rgbd2D.position.x + Input.GetAxis("Horizontal") * moveSpeed;
		float vertiMove = rgbd2D.position.y + Input.GetAxis("Vertical") * moveSpeed;

		Vector2 destination = new Vector2(horiMove, vertiMove);

		rgbd2D.position = Vector2.Lerp(rgbd2D.position, destination, moveRate * Time.deltaTime);
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

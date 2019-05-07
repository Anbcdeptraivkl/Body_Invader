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
	Rigidbody2D rgbd2D;

	void Start () {
		rgbd2D = gameObject.GetComponent<Rigidbody2D>();
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
		Vector2 movementVector = new Vector2(horiMove, 0);
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

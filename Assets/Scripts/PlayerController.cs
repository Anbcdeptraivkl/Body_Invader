using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundary{
	public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public struct DashAttributes {
	public float dashDistance;
	public float dashCooldown;
	public int dashCost;

	DashAttributes(float distance = 50.0f, float cooldown = 2.0f, int cost = 20) {
		dashDistance = distance;
		dashCooldown = cooldown;
		dashCost = cost;
	}
}

public class PlayerController : MonoBehaviour {
	//Movement attributes:
	public float moveSpeed = 2.0f;
	public float moveRate = 5.0f;
	public float dashRate = 10.0f;
	public DashAttributes dashAttributes = new DashAttributes();
	public GameObject dashEffect;
	public Boundary bounds;

	Rigidbody2D rgbd2D;
	PlayerEnergy energy;
	Vector2 lastMoveDir;
	float nextDashTime;

	// Check if Dash Skill is available in this stage
	bool dashEnabled;

	void Start () {
		rgbd2D = gameObject.GetComponent<Rigidbody2D>();
		energy = gameObject.GetComponent<PlayerEnergy>();
		nextDashTime = 0f;
	}

	void LateUpdate() {
		MovePlayer();
		Dash();
		ClampToBound();
	}

	// Move the player with Axis Movement:
	void MovePlayer()
	{
		// Constant Axis Directions
		float horiMove = Input.GetAxis("Horizontal");
		float vertiMove = Input.GetAxis("Vertical");

		lastMoveDir = new Vector2(horiMove, vertiMove).normalized;

		Vector2 destination = new Vector2(
			rgbd2D.position.x + horiMove * moveSpeed, 
			rgbd2D.position.y + vertiMove * moveSpeed);

		rgbd2D.position = Vector2.Lerp(rgbd2D.position, destination, moveRate * Time.deltaTime);
	}

	void Dash() {
		// Conditions Checking for the Dash to be able to Perform
		if (
			// Input
			Input.GetKeyDown(KeyCode.Z) &&
			// Cooldown
			Time.time > nextDashTime
			) 
		{
			if (
				// Energy Checking
				energy.SufficientEnergy(dashAttributes.dashCost)
				) 
			{
				// Reset Cooldown
				nextDashTime = Time.time + dashAttributes.dashCooldown;
				// Deplete Energy
				energy.DepleteEnergy(dashAttributes.dashCost);
				// Dash Positions
				Vector2 destination = rgbd2D.position + lastMoveDir * dashAttributes.dashDistance;
				rgbd2D.position = Vector2.Lerp(rgbd2D.position, destination, dashRate * Time.deltaTime);
				PlayDashEffects();
			}
		}
	}

	void ClampToBound()
	{
		rgbd2D.position = new Vector2(
			Mathf.Clamp(rgbd2D.position.x, bounds.xMin, bounds.xMax),
			Mathf.Clamp(rgbd2D.position.y, bounds.yMin, bounds.yMax)
		);
	}

	void PlayDashEffects() {
		float angle = Mathf.Atan2(lastMoveDir.y, lastMoveDir.x) * Mathf.Rad2Deg - 90;

		GameObject effect = Instantiate(
			dashEffect,
			transform.position,
			Quaternion.identity,
			transform
		);

		effect.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		Destroy(effect, 1.0f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Boundary to CLamp Player's Position in-ranged
[System.Serializable]
public struct Boundary{
	public float xMin, xMax, yMin, yMax;
}


// Dash Skill's Properties
[System.Serializable]
public struct DashSkill {
	public GameObject effect;
	public float distance;
	public float cooldown;
	public int cost;
	public float speedRate;

	DashSkill(float l_distance = 50.0f, float l_cooldown = 2.0f, int l_cost = 20, float l_rate = 10.0f) {
		effect = new GameObject();
		distance = l_distance;
		cooldown = l_cooldown;
		cost = l_cost;
		speedRate = l_rate;
	}
}

[System.Serializable]
public struct Shield {
	public GameObject effect;
	public float duration;
	public float cooldown;
	public int cost;
}

// Plyaer COntroller: Movements, Skillsets and Inputed Behaviours
// Move
// Dash
// Shielding
// Special Weapon(s)
public class PlayerController : MonoBehaviour {
	//Movement attributes:
	public float moveSpeed = 2.0f;
	public float moveRate = 5.0f;

	public DashSkill dashSkill = new DashSkill();

	public Shield shield = new Shield();

	public Boundary bounds;

	Rigidbody2D rgbd2D;
	PlayerEnergy energy;
	Vector2 lastMoveDir;
	float nextDashTime;
	float nextShieldTime;
	int originalLayer;

	// Check if Dash Skill is available in this stage
	bool dashUpgraded;
	bool shieldUpgraded;

	void Start () {
		rgbd2D = gameObject.GetComponent<Rigidbody2D>();
		energy = gameObject.GetComponent<PlayerEnergy>();

		nextDashTime = 0f;
		nextShieldTime = 0f;
		originalLayer = gameObject.layer;
	}

	void LateUpdate() {
		MovePlayer();
		Shield();
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
				energy.SufficientEnergy(dashSkill.cost)
				) 
			{
				// Reset Cooldown
				nextDashTime = Time.time + dashSkill.cooldown;
				// Deplete Energy
				energy.DepleteEnergy(dashSkill.cost);
				// Dash Positions
				Vector2 destination = rgbd2D.position + lastMoveDir * dashSkill.distance;
				rgbd2D.position = Vector2.Lerp(rgbd2D.position, destination, dashSkill.speedRate * Time.deltaTime);
				PlayDashEffects();
			}
		}
	}

	
	void Shield() {
		// Conditions Checking for the Dash to be able to Perform
		if (
			// Input
			Input.GetKeyDown(KeyCode.X) &&
			// Cooldown
			Time.time > nextShieldTime
			) 
		{
			if (
				// Energy Checking
				energy.SufficientEnergy(shield.cost)
				) 
			{
				// Reset Cooldown
				nextShieldTime = Time.time + shield.cooldown;
				// Deplete Energy
				energy.DepleteEnergy(shield.cost);
				SpawnShieldWithEffs();
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
			dashSkill.effect,
			transform.position,
			Quaternion.identity,
			transform
		);

		effect.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		Destroy(effect, 1.0f);
	}

	void SpawnShieldWithEffs() {
		GameObject effect = Instantiate(
			shield.effect,
			transform.position,
			Quaternion.identity,
			transform
		);

		// Player become incollidable when shielded (moved to ghost layer)
		gameObject.layer = 8;

		Destroy(effect, 1.0f);
		Invoke("ToOriginalLayer", 1.0f);
	}

	void ToOriginalLayer() {
		gameObject.layer = originalLayer;
	}
}

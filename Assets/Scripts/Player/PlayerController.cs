using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public Animator playerAnimator;

	public Boundary bounds;

	Rigidbody2D rgbd2D;
	PlayerEnergy energy;
	Vector2 lastMoveDir;
	float lastXMove = 0;
	float nextDashTime;
	float nextShieldTime;
	int originalLayer;

	// Check what Items can be Used (by checking Prefs)
	bool usingGun, usingFlame, usingBeam;
	bool gotDash, gotShield, gotDrone;
	bool gotMissile, gotHP, gotEN;

	void Start () {
		rgbd2D = gameObject.GetComponent<Rigidbody2D>();
		energy = gameObject.GetComponent<PlayerEnergy>();

		nextDashTime = 0f;
		nextShieldTime = 0f;
		originalLayer = gameObject.layer;
		// Activate / Set up the Using Prep Items
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
		//Player Animations Updating when changing Left-Right Move Direction
		if (Input.GetKey(KeyCode.LeftArrow)) {
			lastXMove = -1;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			lastXMove = 1;
		} else {
			lastXMove = 0;
		}
		playerAnimator.SetFloat("XSpeed", lastXMove);
		// Vertical Move
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

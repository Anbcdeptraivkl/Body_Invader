using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

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

	DashSkill(float l_distance = 7.5f, float l_cooldown = 2.0f, int l_cost = 15, float l_rate = 11.0f) {
		effect = new GameObject();
		distance = l_distance;
		cooldown = l_cooldown;
		cost = l_cost;
		speedRate = l_rate;
	}
}

// Shield Skills Properties
[System.Serializable]
public struct Shield {
	public GameObject effect;
	public float duration;
	public float cooldown;
	public int cost;
}

// Shot and Upgrades Collections:
// Utilize Prefabs, nested Prefabs and Linking Prefabs for the most effective methods:
[System.Serializable]
public struct Shot {
	public GameObject shotObj;
	public int upgradeLevel;
}

// HP Ui Struct:
[System.Serializable]
public struct HpUi {

	// The Images are disabled by Default and will be enabled when initiated by the main Functions:
	[SerializeField]
	public Image[] HeartsCollection;
	public Sprite fullHPSprite;
	public Sprite lostHPSprite;

}

public class Player : MonoBehaviour {
	// General-usage Components
	Rigidbody2D rgbd2D;
	Collider2D playerCollider;
    CamShake camShaker;
    Animator playerAnimator;
	GameOver gameOverController;

    // Configurations Resources (in the Form of JSON files)
    [Header("Configs")]
    public TextAsset configsJson;
    PlayerConfigs playerConfigs;
    // Player will not be Controllable on Winning Sequence, this flag is solely for that Purpose
    bool controllable = true;

    [Header("Attacks")]
    public List<Shot> shotList = new List<Shot>();
    public Transform shotSpawn;
    [SerializeField]
    float fireRate = 0.5f;
    float shootDelayTime = 0.0f;
    GameObject shot;
    int shotLevel;


    [Header("Movements")]
    //Movement attributes:
    [SerializeField]
	float moveSpeed = 2.0f;
    [SerializeField]
	float moveRate = 5.0f;
    [SerializeField]
	Boundary bounds;
	Vector2 lastMoveDir;
	float lastXMove = 0;
    bool hittable = true;


    [Header("Skills")]
	public DashSkill dashSkill = new DashSkill();

	public Shield shield = new Shield();

	float nextDashTime;
	float nextShieldTime;
	int originalLayer;
	// Check what Items can be Used (by checking Prefs)
	bool usingGun, usingFlame, usingBeam;
	bool gotDash, gotShield, gotDrone;
	bool gotMissile, gotHP, gotEN;


    [Header("Energy")]
    public Image fillEnergyBar;

    // The max Energy Value
    public float maxEnergy = 100;
    // Time for the Enrgy to deplete
    [SerializeField]
    float enDepleteRate = 1f;

    [SerializeField]
    float enNextRate = 0.1f;
    float nextTime = 0f;
    static int currentEnergy;


	[Header("Health Manager")]
	// The Structure for HP UI in action:
    public HpUi PlayerHpUi;
    public float invinTime = 0.75f;

    [SerializeField]
    private int maxHp = 3;

    [SerializeField]
    protected int currentHp;
    // External references:
    public GameObject playerExplosion;
    public AudioSource hitSound;
    public AudioSource hpUpSound;
	//Invincible checker: will affect on enemy's shots and contacts behaviours:
    protected bool isInvin;
    // Hp Mechanics Upgraded or not (not by default)
    bool hpUpgraded = false;


	[Header("Upgrades")]
	public AudioSource upgReceivingSfx;
	PlayerMissileLauncher missileLauncher;
    

	/* UNITY BUILT-IN GAME FLOWS */
    void Start() {
        // Components
        rgbd2D = gameObject.GetComponent<Rigidbody2D>();
		// Activate / Set up the Using Prep Items
        // Initiate the Starting weapons:
        shotLevel = 0;
        shot = shotList[shotLevel].shotObj;
        // Skills Setup
		nextDashTime = 0f;
		nextShieldTime = 0f;
		originalLayer = gameObject.layer;
        // Energy
		currentEnergy = (int)maxEnergy;
		 // Initiate the Max Hp and Current Hp:
        maxHp = (hpUpgraded) ? 4 : 3;
        currentHp = maxHp;
		//Invin initiate Values:
        isInvin = false;
        // Display Hearts:
        DrawHearts();
		GetRefComponents();

        // Setting Configs from Data file
        SetConfigs();
    }

    // Checking Events and Inputs:
    // Input: 
    //  - Hold Space to fire
    void Update() {
        if (controllable)
            ShootingUpdate();
        SetEnergyBarFill();
    }

    void LateUpdate() {
        if (controllable) {
            MovePlayer();
            Shield();
            Dash();
            ClampToBound();
        }
	}

	 void OnTriggerEnter2D(Collider2D other)
    {
        // After the Boss is defeated, the Player can no longer get hit
        if (hittable) {
		    CheckOnGettingShot(other);
        }
        CheckOnGettingUpgrades(other);
    }

	/* PUBLIC APIs */
    #region Public APIs
	/* ATTACKS API */
    public void ShotUpgrade() {
        // Increase shot level and re-assign the weapons when receiving upgrades:
        if (shotLevel + 1 < shotList.Count) {
            shotLevel++;
            shot = shotList[shotLevel].shotObj;
        }
    }

    public void ShotDowngrade() {
        // Decrease Shot Levels on Negative Effects of Enemies:
        shotLevel--;
        shot = shotList[shotLevel].shotObj;
    }

    public int GetWeaponLevel() {
        return shotLevel;
    }
	/* ENERGY API */
    public bool SufficientEnergy(int amount) {
        if (currentEnergy >= amount)
            return true;
        else {
            ResponseWhenInsufficientEnergy();
            return false;
        }
    }
    public void DepleteEnergy(int amount) {
            currentEnergy -= amount;
    }
    public void RefillEnergy(int amount) {
        if (currentEnergy < maxEnergy) {
            currentEnergy += amount;
        }
    }
	/* HP API */
	public void SetHpUpgrade(bool value) {
        hpUpgraded = value;
    }

    // Deplete HP, then Update UI, then Play effects and start invincible frames for player:
    public void DecreaseHp(int amount = 1) {

        currentHp -= amount;

        if (currentHp <= 0) {
            PlayerExplode();
        }

        OnLosingHpUi();

        // To visual and sound effects:
        PlayImmersiveHPEffects();

        // INvincible frames:
        StartCoroutine("Invincible");

    }

	 // heal when getting Hearts:
    public void IncreaseHp(int amount = 1) {

        if (currentHp < maxHp) {

            currentHp += amount;

        }

        // Safe-proof range:
        if (currentHp > maxHp) { currentHp = maxHp;}

        // Re-Draw the Hp Sprites after Healing:
        OnHealingHpUi();
    }
	public int CurrentHp() {
        return currentHp;
    }

    public bool CheckInvin() {
        return isInvin;
    }

    public bool CheckAlive() {
        return currentHp > 0 ? true : false;
    }
    public void BeInvincible() {
        hittable = false;
    }
    public bool CanGetHit() {
        return hittable;
    }
    public void NoMoreControls() {
        controllable = false;
    }
    public void Controllable() {
        controllable = true;
    }
    #endregion

	/* HIDDEN INTERNAL WORKINGS */
	// Getting the Self-references or External Components needed for the COmposited Operations
	void GetRefComponents() {
		// Getting Game COntroller references and components:
		missileLauncher = gameObject.GetComponent<PlayerMissileLauncher>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		if (gameControllerObject != null) 
		{
			gameOverController = gameControllerObject.GetComponent<GameOver>();
		}
			else
			{
				Debug.Log("Failed to load <GameController> script component.");
			}

        // Getting camera components:
        GameObject mainCam = GameObject.FindWithTag("MainCamera");

        if (mainCam != null) {
            camShaker = mainCam.GetComponent<CamShake>();
        } else {
            Debug.Log("No camera found.");
        }

        // Host components:
        playerCollider = GetComponent<CapsuleCollider2D>();

        playerAnimator = GetComponent<Animator>();
	}

    void SetConfigs() {
        // Reading Data
        playerConfigs = JsonUtility.FromJson<PlayerConfigs>(configsJson.text);
        // Assigning Fields
        // Attacks
        fireRate = playerConfigs.fireRate;
        // Movements
        moveSpeed = playerConfigs.moveSpeed;
        moveRate = playerConfigs.moveRate;
        bounds.xMax = playerConfigs.movementBounds.x;
        bounds.xMin = -playerConfigs.movementBounds.x;
        bounds.yMax = playerConfigs.movementBounds.y;
        bounds.yMin = -playerConfigs.movementBounds.y;
        // Dash Skill Configs
        dashSkill.distance = playerConfigs.dash.distance;
        dashSkill.cooldown = playerConfigs.dash.cooldown;
        dashSkill.cost = playerConfigs.dash.cost;
        dashSkill.speedRate = playerConfigs.dash.speed;
        // Shield SKill Configs
        shield.duration = playerConfigs.shield.duration;
        shield.cooldown = playerConfigs.shield.cooldown;
        shield.cost = playerConfigs.shield.cost;
        // Miscelaneous Properties
        enDepleteRate = playerConfigs.enDepleteRate;
        enNextRate = playerConfigs.enNextRate;
        maxHp = playerConfigs.maxHp;
    }

	/* ATTACKING MECHANICS AND CONTROLLERS */
    private void Fire()
    {
        // Normal shooting:
        //No rotation, only speed!
        Instantiate(shot, shotSpawn.position, Quaternion.identity);
    }

    // Shooting Loop
    void ShootingUpdate() {
        // Fixed time Step Mechanics: Delay and Frie Rate contribute to the overall firing speed:
        shootDelayTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && shootDelayTime > fireRate) {
            Fire();
            // Reset the time step and start the new iteration:
            shootDelayTime = 0.0f;
        }
    }

    /* MOVEMENTS AND SKILLS OPERATIONS */
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
				SufficientEnergy(dashSkill.cost)
				) 
			{
				// Reset Cooldown
				nextDashTime = Time.time + dashSkill.cooldown;
				// Deplete Energy
				DepleteEnergy(dashSkill.cost);
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
				SufficientEnergy(shield.cost)
				) 
			{
				// Reset Cooldown
				nextShieldTime = Time.time + shield.cooldown;
				// Deplete Energy
				DepleteEnergy(shield.cost);
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

    /* ENERGY HELPERS*/
    void SetEnergyBarFill() {
        // Set Fill Bar
        fillEnergyBar.fillAmount = Mathf.Lerp(fillEnergyBar.fillAmount, currentEnergy / maxEnergy, enDepleteRate * Time.deltaTime);
    }

    // Testing fot Input
    void Debug_EnergyInputHandler() {
        // Deplete
         if (Input.GetKeyDown(KeyCode.E) && Time.time > nextTime) {
            // Increase for the New Countdown
            nextTime = Time.time + enNextRate;
            DepleteEnergy(10);
        } else if (Input.GetKeyDown(KeyCode.R) && Time.time > nextTime) {
            nextTime = Time.time + enNextRate;
            RefillEnergy(10);
        }
    }

    void ResponseWhenInsufficientEnergy() {
        // 
        Debug.Log("Insufficient Energy!");
    }

	/* HP AND HP UI INNNER CONTROLLERS */
	void DrawHearts() {
        // Draw the Hp Sprites:
        for (int i = 0; i < PlayerHpUi.HeartsCollection.Length; i++) {
            if (i < currentHp) {
                PlayerHpUi.HeartsCollection[i].gameObject.SetActive(true);
            } else {
                PlayerHpUi.HeartsCollection[i].gameObject.SetActive(false);
            }
        }
    }

	void OnLosingHpUi() {
        // Update the Player and UI state based on the current HP:
        for (int i = 0; i < PlayerHpUi.HeartsCollection.Length; i++) {
            
            // Swapping Sprite and Playing Effects:
            if (i < currentHp) {
                PlayerHpUi.HeartsCollection[i].sprite = PlayerHpUi.fullHPSprite;
            } else {
                PlayerHpUi.HeartsCollection[i].sprite = PlayerHpUi.lostHPSprite;
            }
        }
    }

	void OnHealingHpUi() {
        // Update the Player and UI state based on the current HP:
        for (int i = 0; i < PlayerHpUi.HeartsCollection.Length; i++) {
            
            // Swapping Sprite and Playing Effects:
            if (i < currentHp) {
                PlayerHpUi.HeartsCollection[i].sprite = PlayerHpUi.fullHPSprite;
            } else {
                PlayerHpUi.HeartsCollection[i].sprite = PlayerHpUi.lostHPSprite;
            }
        }
    }

	void PlayImmersiveHPEffects() {

        camShaker.StartShaking();
        
        playerAnimator.SetTrigger("Hit");

        hitSound.Play();

    }

    // PLayer destroyed when hp depleted:
    void PlayerExplode() {
        //Check Death, then Explosions and Game Over:
          
        // Instantiate the explosion and play it for 2 secs:
        playerExplosion = Instantiate(
            playerExplosion, 
            transform.position,
            transform.rotation) as GameObject;
        
        Destroy(playerExplosion, 2.0f);

        //Game over since the player has been destroyed:
        gameOverController.Over();

        //Destroy the Player and end the game:
        Destroy(gameObject);
            
    }

    // Invincible for fixed amount of frames:
    IEnumerator Invincible() {
        
        isInvin = true;

        yield return new WaitForSeconds(invinTime);

        isInvin = false;
    }

	/* INNER REACTIONS AND EFFECTS */
	// Check if you are Getting hit by Enemy's Shots
	void CheckOnGettingShot(Collider2D shot) {
		if (shot.gameObject.tag == "EnemyShot")
        {
            //Check for player Invincible frames before acting:
            if (!CheckInvin()) {
                DecreaseHp();
            }
            // Decreasing Player HP and Play effects:
            Destroy(shot.gameObject);

        }
	}

	void CheckOnGettingUpgrades(Collider2D upgrade) {
		 if (upgrade.gameObject.tag == "Upgrade") {
            //Play Power up Sound!
            upgReceivingSfx.Play();
            // Checking for Upgrade types (using the hierachy tags system), then start activating features:
            UpgradeIdentifier identifier = upgrade.gameObject.GetComponent<UpgradeIdentifier>();
			// Dealing with each Upgrade Type Approriately
            if (identifier) {
                switch (identifier.GetUpgradeType()) {
                    case UpgradeType.StrongShot:
                    {
                        ShotUpgrade();
                    }
                    break;

                    case UpgradeType.Heart:
                    {
                        IncreaseHp();
                    }
                    break;

                    case UpgradeType.Missile:
                    {
                        missileLauncher.IncreaseMissile();
                    }
                    break;
                }
				Debug.Log("Applied Upgrade!");
				// Destroy the Upgrade orbs after collisions:
				Destroy(upgrade.gameObject);
            }
        }
	}
}
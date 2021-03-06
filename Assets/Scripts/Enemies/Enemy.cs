using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  - Struct storing Upgrade Prefabs data:
[System.Serializable]
public struct DropItem {
    public string name;
    public GameObject obj;
    public float rarity;

    public int amount;
}

public class Enemy: MonoBehaviour {
    // Remember to Set Configs before Assigning any Permanent Data Variables or else they will received the default values
    public TextAsset configsJson;
    protected EnemyConfigs configs;
	
	[Header("Status")]
    [SerializeField]
	protected int baseHP = 1;
    [SerializeField]
    protected int energyReward = 1;
    [SerializeField]
    protected int chargeReward = 1;
    // A Short Invicible time on first Spawning
    [SerializeField]
    protected float invincibleTimer = 0.1f;
	// The Number of all the enemies inside the scene
	protected static int count = 0;
	protected float currentHP;
    protected bool stillLiving;
	protected bool gotMissiled;

	// Every Enemies on Death will Drop Rewards one way or another
	//  - Boss Dropping and Dying will be handled seperatedly in the Boss Component
	[Header("Dropper")]
    //  - Collections:
    public List<DropItem> randomDropList = new List<DropItem>();
    public List<DropItem> persistentDropList = new List<DropItem>();
    //  - Properties:
    public float dropChance;

	// Visual Effects and Animations
	[Header("Effects")]
	[SerializeField]
	protected GameObject hitShockParticle;
    [SerializeField]
	GameObject shotExplosion;
    [SerializeField]
	AudioSource explodingSound;

	Animator animator;
    CamShake camShaker;

	void Awake() {
		count++;
	}

	void OnDestroy() {
		count--;
	}

	protected void Start() {
		// Main Animator for All Animations
		animator = gameObject.GetComponent<Animator>();
        // Getting Cam Shaker component:
        GameObject mainCam = GameObject.FindWithTag("MainCamera");
        if (mainCam != null) {
            camShaker = mainCam.GetComponent<CamShake>();
        }
        // Setting up Configurations
        SetConfigs();
        // HP Setting
		currentHP = Mathf.Abs(baseHP);
        // Attacked Flags
        gotMissiled = false;
        stillLiving = true;
        // Operations
        //*  - Invincibility
        Invincible();
        Invoke("StopInvin", invincibleTimer);
	}

	virtual protected void OnTriggerEnter2D (Collider2D other) {
		// On Getting Shot
		if (other.gameObject.tag != "Boundary" ) {
            // Getting shot by Player
			if (other.gameObject.tag == "Shot") {
                // Check the Shot Damage,then Decrease Hp and Destroy the SHot:
                float shotDmg = other.gameObject.GetComponent<ShotDamage>().GetDamage();
				// Decreasing HP and Checking if Dying
                DecreaseHP(shotDmg);
				stillLiving = Alive();
                // On hit Animations and Effects:
                PlayOnHitEffects(other);
                // Destroy the shot objects after colliding:
                Destroy(other.gameObject);
            } else if (other.gameObject.tag == "Player") // Colliding with the player themselves
            {
				Player playerScript = other.gameObject.GetComponent<Player>();
				if (!playerScript.CheckInvin() && playerScript.CanGetHit()) {
					playerScript.DecreaseHp();
				}
            }
		}
	}
    
    #region Public APIs
    // Checking for Enemies remaining on the Screen
	static public bool Wiped() {
		return (count <= 0);
	}

	public int GetCount() {
        return count;
    }
	
	 public float GetCurrentHP() {
        return currentHP;
    }

	public bool Living() {
		return stillLiving;
	}
    #endregion

    void SetConfigs() {
        configs = JsonUtility.FromJson<EnemyConfigs>(configsJson.text);
        baseHP = configs.baseHp;
        energyReward = configs.enReward;
        invincibleTimer = configs.invincibleTimer;
        dropChance = configs.dropChance;
    }

	public void DecreaseHP(float value = 1) {
        currentHP -= value;

        if (value >= 10) //Rocket Dmg
            gotMissiled = true;
        gotMissiled = false;
    }

	void IncreaseHP(float value = 1) {
        currentHP += value;
    }

	protected void PlayOnHitEffects(Collider2D other) {
        // If still alive: Hit Shock:
        if (stillLiving) {
            // BLinking animations:
            if (animator) {
                animator.SetTrigger("Hit");
				// CHecking for the Colliding shot types, and instantiate the effects as followed:
				GameObject hitParticle;
				hitParticle = Instantiate(
					hitShockParticle,
					other.gameObject.transform.position,
					other.gameObject.transform.rotation
				) as GameObject;

				Destroy(hitParticle, 1.0f);
				animator.ResetTrigger("Hit");
			}
        }
    }

    // Bosses have different Dying mechanics
	bool Alive () {
        if (currentHP > 0) {
            return true;
        }
        else
        {
            // Die if not dying already
			Dying();
            return false;
        }
    }

	// Die and Explode:
    void Dying() {
        // Shake Cam
        camShaker.StartShaking(0.2f, 0.1f);
        // Refill Energy (by living Player) and Charge Up Weapon for Upgrading
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null) {
            Player player = playerObj.GetComponent<Player>();
            PlayerChargeWeapon playerWeapon = playerObj.GetComponent<PlayerChargeWeapon>();
            if (player != null) {
                player.RefillEnergy(energyReward);
            }
            if (playerWeapon != null) {
                playerWeapon.Charge(chargeReward);
            }
        }
        // Item Drop:
        CalculateRandomDrop();
        // Loot Drop:
        DropPersistences();
        // Dying Process
		//  - Spawn and Control Explosions
        shotExplosion = Instantiate(
            shotExplosion, 
            transform.position, 
            transform.rotation) as GameObject;
        Destroy(shotExplosion, 0.5f);
        //  - Playing Sounds
        if (!gotMissiled) {
            explodingSound.Play();
        }
        //  - Destroyed dying enemies after finish dying hehaviours
        Destroy(gameObject);
    }

    protected void CalculateRandomDrop() {

        float chance = Random.Range(0, 100) + 1; //the 0 is inclusive, while 100 is excluded

        if (chance <= dropChance) {
            DropUpgrade();
        }
    }

    protected void DropUpgrade() {

        // The total Drop Weight:
        float dropWeight = 0;

        for (int i = 0; i < randomDropList.Count; ++i) {
            dropWeight += randomDropList[i].rarity;
        }

        // Random drop rate:
        float rate = Random.Range(0, dropWeight) + 1;

        // Cycle through the list again to determine which upgrades will drop::
        for (int j = 0; j < randomDropList.Count; ++j) {
            // If in-range, spawn and return, else decrease the rate and continue looping through other upgrades:
            if (rate < randomDropList[j].rarity) {
                Instantiate(
                    randomDropList[j].obj,
                    gameObject.transform.position,
                    Quaternion.identity
                );
                break;
            }

            rate -= randomDropList[j].rarity;
        }
    }

    protected void DropPersistences() {
        StartCoroutine("DropPersistenceRoutine");
    }

    IEnumerator DropPersistenceRoutine() {
        // Checking if the List is empty:
        if (persistentDropList.Count <= 0) {
            yield break;
        }

        for (int i = 0; i < persistentDropList.Count; i++) {
            // Get each Drop Items:
            DropItem drop = persistentDropList[i];

            // Dropping!
            // many Different Kinds:
            for (int j = 0; j < drop.amount; j++) {
                Instantiate(
                    drop.obj,
                    transform.position,
                    Quaternion.identity);
            }
        }
    }

     void Invincible() {
        //Disable the Collider == no damage taken:
        GetComponent<Collider2D>().enabled = false;
    }

    void StopInvin() {
        //Stop being invin:
        GetComponent<Collider2D>().enabled = true;

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour {
	
	[Header("Status")]
	public int baseHP;
    public int energyReward = 5;
    // A Short Invicible time on first Spawning
    public float timer = 0.25f;
	// The Number of all the enemies inside the scene
	static int count = 0;
	float currentHP;
    bool stillLiving;
	bool gotMissiled;

	// Every Enemies on Death will Drop Rewards one way or another
	//  - Boss Dropping and Dying will be handled seperatedly in the Boss Component
	[Header("Dropper")]
	PlayerEnergy eneryManager;
	//  - Struct storing Upgrade Prefabs data:
    [System.Serializable]
    public struct DropItem {
        public string name;
        public GameObject obj;
        public float rarity;

        public int amount;
    }
    //  - Collections:
    public List<DropItem> randomDropList = new List<DropItem>();
    public List<DropItem> persistentDropList = new List<DropItem>();
    //  - Properties:
    public float dropChance;
    public float delayBtwItems;
    public float delayBtwnPieces = 0.1f;

	// Visual Effects and Animations
	[Header("Effects")]
	[SerializeField]
	protected GameObject hitShockParticle;
    public GameObject shotExplosion;
    public AudioSource explodingSound;

	Animator animator;
    CamShake camShaker;

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

	void Awake() {
		count++;
	}

	void OnDestroy() {
		count--;
	}

	void Start() {
		// Main Animator for All Animations
		animator = gameObject.GetComponent<Animator>();
        // Getting Cam Shaker component:
        GameObject mainCam = GameObject.FindWithTag("MainCamera");
        if (mainCam != null) {
            camShaker = mainCam.GetComponent<CamShake>();
        } else {
            Debug.Log("No camera found.");
        }
		// Getting Player's Components
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) 
		{
			
			eneryManager = player.GetComponent<PlayerEnergy>();
		}
			else
			{
				Debug.Log("Failed to load <Player> Reference");
			}
        // HP Setting
		currentHP = Mathf.Abs(baseHP);
        // Attacked Flags
        gotMissiled = false;
        stillLiving = true;
        // Operations
        //*  - Invincibility
        Invincible();
        Invoke("StopInvin", timer);
	}

	void OnTriggerEnter2D (Collider2D other) {
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
				if (!playerScript.CheckInvin()) {

					playerScript.DecreaseHp();

				}
            }
		}
	}

	void DecreaseHP(float value = 1) {
        currentHP -= value;

        if (value >= 10) //Rocket Dmg
            gotMissiled = true;
        gotMissiled = false;
    }

	void IncreaseHP(float value = 1) {
        currentHP += value;
    }

	void PlayOnHitEffects(Collider2D other) {
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

        // Refill Energy
        if (eneryManager)
            eneryManager.RefillEnergy(energyReward);
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

    void CalculateRandomDrop() {

        float chance = Random.Range(0, 100) + 1; //the 0 is inclusive, while 100 is excluded

        if (chance <= dropChance) {
            DropUpgrade();
        }
    }

    void DropUpgrade() {

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

    void DropPersistences() {
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
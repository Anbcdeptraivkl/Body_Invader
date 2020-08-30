using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss: Enemy {
    // Flash Bang Particles that will be spawned
    public GameObject bang;
    // The White flash is actually just a UI panel with Fade In/Out Animations that will be Triggered on Boss Defeated 
    Animator whiteFlashAnimator;
    [SerializeField]
    float bangDuration = 0.4f;
    [SerializeField]
    float pauseBetweenBangs = 0.3f;
    [SerializeField]
    int explosionsCount = 5;
    // State Flags
    bool bossSpawned = false;
    // Disable manything on Boss Dying
    bool bossDying = false;

    // References
    Animator bossAnimator;
    Collider2D bossCollider;
    BackgroundScrolling backScroll;

    void Start() {
        base.Start();
        bossSpawned = true;
        // Stop Scrolling background when the Boss spawned
        backScroll = GameObject.FindWithTag("Background").GetComponent<BackgroundScrolling>();
        // Animator
        bossAnimator = GetComponent<Animator>();
        // Collider
        bossCollider = GetComponent<Collider2D>();
        whiteFlashAnimator = GameObject.Find("White Flash").GetComponent<Animator>();
        backScroll.StopScrolling();
    }

    void Update() {
        InvokeBossBehaviours();
    }

    override protected void OnTriggerEnter2D(Collider2D other) {
        // Ignore Bounds
		if (other.gameObject.tag != "Boundary" ) {
            // Getting shot by Player
			if (other.gameObject.tag == "Shot") {
                Debug.Log("Got shotted!");
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

    void OnDestroy() {
        // Win when the Boss is destroyed
        Debug.Log("Boss defeated!");
        LevelComplete.Win();
    }

    public bool IsDying() {
        return bossDying;
    }

    // The Boss Dying behaviours are nothing like normal enemies and will be defined separatedly
    bool Alive() {
        if (currentHP > 0) {
            return true;
        }
        else
        {
            // Die if not dying already
			StartCoroutine(InvokeBossDying());
            return false;
        }
    }

    void InvokeBossBehaviours() {

    }

    // COroutine for the Dying sequences of Bosses
    IEnumerator InvokeBossDying() {
        bossDying = true;
        // Disable Colliding by moving Self to a different Physics Layer Mask
        gameObject.layer = LayerMask.NameToLayer("Hollow");
        // Player
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (player != null) {
            // Invincible so the player won't be shotted or collided harmfully after the Boss is killed
            player.BeInvincible();
            // Refill Energy (for when there would be Extra Bosses in the Level)
            player.RefillEnergy(energyReward);
        }
        // Item Drop:
        CalculateRandomDrop();
        // Loot Drop:
        DropPersistences();
        // Dying Process
        //  Shaking Animation
        bossAnimator.SetTrigger("Defeated");
        // Big Bang and the Screen Flash to White
        whiteFlashAnimator.SetTrigger("Flash");
        //  Spawning Small Explosions for a set amount of time with small Pauses in between
        for (int i = 0; i < explosionsCount; i++) {
        //   Spawn on random point inside Collider bounds
            GameObject smallBang = Instantiate(
                bang,
                GetRandomPointInBounds(),
                Quaternion.identity
            );
            Destroy(smallBang, bangDuration);
            yield return new WaitForSeconds(pauseBetweenBangs);
        }
        //  - Destroyed dying enemies after finish dying hehaviours
        Destroy(gameObject);
    }

    Vector2 GetRandomPointInBounds() {
        return new Vector2(
            Random.Range(bossCollider.bounds.min.x, bossCollider.bounds.max.x),
            Random.Range(bossCollider.bounds.min.y, bossCollider.bounds.max.y)
        );
    }
}
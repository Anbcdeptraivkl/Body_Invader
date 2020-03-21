using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control player behaviours when Receiving and applying Upgrades (from Colllision and Logical Checking):
public class PlayerUpgrade: MonoBehaviour {
    public AudioSource upgReceivingSfx;

    // References:
    PlayerAttacking playerWeapon;
    PlayerMissileLauncher playerMissile;
    PlayerHPManager hpManager;

    void Start() {

        playerWeapon = gameObject.GetComponent<PlayerAttacking>();
        playerMissile = gameObject.GetComponent<PlayerMissileLauncher>();
        hpManager = gameObject.GetComponent<PlayerHPManager>();
    }

    // After checking and triggering events, the real behaviours and actions will be performed in the Update functions (and their complements):
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Upgrade") {
            //Play Power up Sound!
            upgReceivingSfx.Play();
            // Checking for Upgrade types (using the hierachy tags system), then start activating features:
            UpgradeIdentifier identifier = other.gameObject.GetComponent<UpgradeIdentifier>();

            if (identifier) {
                switch (identifier.GetUpgradeType()) {
                    case UpgradeType.StrongShot:
                    {
                        playerWeapon.ShotUpgrade();
                    }
                    break;

                    case UpgradeType.Heart:
                    {
                        hpManager.IncreaseHp();
                    }
                    break;

                    case UpgradeType.Missile:
                    {
                        playerMissile.IncreaseMissile();
                    }
                    break;
                }

            Debug.Log("Applied Upgrade!");

            // Destroy the Upgrade orbs after collisions:
            Destroy(other.gameObject);
            }
        }
    }
}
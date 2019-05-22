using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control player behaviours when Receiving and applying Upgrades:
public class PlayerUpgrade: MonoBehaviour {

    public float strongShootTime = 5.0f;

    PlayerAutoShooting autoShooter;

    void Start() {

        autoShooter = gameObject.GetComponent<PlayerAutoShooting>();

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Upgrade") {

            // Checking for Upgrade types (using the hierachy tags system), then start activating features:
            string upType = other.gameObject.transform.GetChild(0).gameObject.tag;

            if (upType == "StrongShot") {
                StartCoroutine("StrongShotUpg");
            }

            Debug.Log("Applied Upgrade!");

            // Destroy the Upgrades after collisions:
            Destroy(other.gameObject);
        }
    }

    IEnumerator StrongShotUpg() {

        Debug.Log("Start Strong Shooting");

        autoShooter.StartStrongShooting();

        yield return new WaitForSeconds(strongShootTime);

        autoShooter.StopStrongShooting();
    }
}
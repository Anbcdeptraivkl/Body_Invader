using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control player behaviours when Receiving and applying Upgrades:
public class PlayerUpgrade: MonoBehaviour {

    public float strongShootTime = 5.0f;

    public int upScore = 30;

    PlayerAutoShooting autoShooter;

    ScoreManager scoreMng;

    void Start() {

        autoShooter = gameObject.GetComponent<PlayerAutoShooting>();

        GameObject controller = GameObject.FindGameObjectWithTag("GameController");

        if (controller) {
            scoreMng = controller.GetComponent<ScoreManager>();
        } else {
            Debug.Log("No game controller found");
        }

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Upgrade") {

            // Increase Score for getting upgrades:
            scoreMng.UpdateScore(upScore);

            // Checking for Upgrade types (using the hierachy tags system), then start activating features:
            string upType = other.gameObject.transform.GetChild(0).gameObject.tag;

            if (upType == "StrongShot") {
                StartCoroutine("StrongShotUpg");
            }

            Debug.Log("Applied Upgrade!");

            // Destroy the Upgrade orbs after collisions:
            Destroy(other.gameObject);
        }
    }

    // Strong Shooting Upgrade: by invoking strong shoot functionality in the auto shooter component:
    IEnumerator StrongShotUpg() {

        Debug.Log("Start Strong Shooting");

        autoShooter.StartStrongShooting();

        yield return new WaitForSeconds(strongShootTime);

        autoShooter.StopStrongShooting();
    }
}
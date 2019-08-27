using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control player behaviours when Receiving and applying Upgrades (from Colllision and Logical Checking):
public class PlayerUpgrade: MonoBehaviour {

    public float strongShootTime = 5.0f;

    public int upScore = 20;

    public AudioSource upgReceivingSfx;


    PlayerAttacking autoShooter;

    ScoreManager scoreMng;


    void Start() {

        autoShooter = gameObject.GetComponent<PlayerAttacking>();
       

        GameObject controller = GameObject.FindWithTag("GameController");

        if (controller) {
            scoreMng = controller.GetComponent<ScoreManager>();
        } else {
            Debug.Log("No game controller found");
        }
    }

    // After checking and triggering events, the real behaviours and actions will be performed in the Update functions (and their complements):
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Upgrade") {

            // Increase Score for getting upgrades:
            scoreMng.UpdateScore(upScore);

            //Play Power up Sound!
            upgReceivingSfx.Play();

            // Checking for Upgrade types (using the hierachy tags system), then start activating features:
            UpgradeIdentifier identifier = other.gameObject.GetComponent<UpgradeIdentifier>();

            if (identifier) {
                switch (identifier.GetUpgradeType()) {
                    case UpgradeType.StrongShot:
                    {
                        autoShooter.ShotUpgrade();
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
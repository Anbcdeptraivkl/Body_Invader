using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control player behaviours when Receiving and applying Upgrades (from Colllision and Logical Checking):
public class PlayerUpgrade: MonoBehaviour {

    public float strongShootTime = 5.0f;

    public float shieldTime = 5.0f;

    public int upScore = 30;

    public GameObject shield_Prefab;


    PlayerAutoShooting autoShooter;

    GameObject shieldInstance;

    Renderer sprite_Component;

    Color oldColor, currentColor;

    ScoreManager scoreMng;

    bool activeShield;

    void Start() {

        autoShooter = gameObject.GetComponent<PlayerAutoShooting>();

        sprite_Component = gameObject.transform.Find("VFX").gameObject.GetComponent<Renderer>();
       

        GameObject controller = GameObject.FindWithTag("GameController");

        if (controller) {
            scoreMng = controller.GetComponent<ScoreManager>();
        } else {
            Debug.Log("No game controller found");
        }

        oldColor = sprite_Component.material.color;

        Debug.Log(oldColor);

        activeShield = false;

    }

    // After checking and triggering events, the real behaviours and actions will be performed in the Update functions (and their complements):
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Upgrade") {

            // Increase Score for getting upgrades:
            scoreMng.UpdateScore(upScore);

            // Checking for Upgrade types (using the hierachy tags system), then start activating features:
            string upType = other.gameObject.transform.GetChild(0).gameObject.tag;

            if (upType == "StrongShotUpg") {
                StartCoroutine("StrongShotUpg");
            } else {
                if (upType == "ShieldUpg") {
                    StartCoroutine("ShieldUpg");
                }
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

    // Toggling Shield using instantiating methods:
    IEnumerator ShieldUpg() {

        // Toggle activation on Shield Player's Child object (no using referene, but call directly):
        if (!activeShield) {
            shieldInstance = Instantiate(shield_Prefab, transform);

            activeShield = true;

            ChangeToNewColor();
        }


        yield return new WaitForSeconds(shieldTime);


        // Then Disable until receiving more upgrades:
        if (activeShield) {
            Destroy(shieldInstance, shieldTime);

            activeShield = false;

            ReturnToOldColor();
        }

        yield break;
        
    }

    void ChangeToNewColor() {

        sprite_Component.material.color = new Color(0.9f, 0.3f, 1.0f, 1.0f);

    }

    void ReturnToOldColor() {

        sprite_Component.material.color = oldColor;

    }
}
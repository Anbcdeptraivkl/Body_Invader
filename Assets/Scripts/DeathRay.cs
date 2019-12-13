using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRay: MonoBehaviour {
    [SerializeField]
    int dmg = 1;
    bool shielded = false;

    // Deal Dmg to Player when Touch (Enter)
    private void OnTriggerEnter2D(Collider2D other) {
        // Shield flag
        if (other.CompareTag("Shield")) {
            // If touch Shield before touching player, won't continue Detecting Player for this period
            shielded = true;
        }

        if (other.CompareTag("Player") && !shielded) {
            other.gameObject.GetComponent<PlayerHPManager>().DecreaseHp(dmg);
            RayEffects();
        } else if (other.CompareTag("Player") && shielded) {
            ShieldedEffects();
            // Reset Shielded Status
            shielded = false;
        }
    }

    // Play Impact Particle Effects (SFXs and VFXs)
    void RayEffects() {

    }

    void ShieldedEffects() {

    }
}
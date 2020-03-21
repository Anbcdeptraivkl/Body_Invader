using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Actions and Sequences that will be performed when the Drop Items instantiated
// - Including: Upgrades(!?) Money and Loots
public class DropBehaviour: MonoBehaviour {
    // The absolute for the random velocity at the beginning:
    public Vector2 burstSpeed;
    // Burst-out time:
    public float burstTime;
    // Standing still time:
    public float stillTime;

    // References:
    Vector2 currentSetSpeed;
    Rigidbody2D rgbd;

    bool finishBursting;

    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();

        finishBursting = false;
        
        // Burst out after spawn, randomly:
        StartCoroutine("BurstOut");
    }

    void Update() {
        if (!finishBursting)
            rgbd.velocity = new Vector2(currentSetSpeed.x, currentSetSpeed.y);
    }

    public bool DoneBursting() {
        return finishBursting;
    }

    IEnumerator BurstOut() {
    // The Coin bursts out:
        float burstX = Random.Range(-burstSpeed.x, burstSpeed.x);
        float burstY = Random.Range(-burstSpeed.y, burstSpeed.y);

        currentSetSpeed = new Vector2(burstX, burstY);
        yield return new WaitForSeconds(burstTime);

        // Stay still for a short amount of time:
        currentSetSpeed = Vector2.zero;
        yield return new WaitForSeconds(stillTime);

        // After that, start the state where the coins move toward the player (Move to Pick-up):
        finishBursting = true;
    }
}
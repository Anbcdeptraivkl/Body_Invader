using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stop Dmgs (from Player COntroller script right when the Shield is activated) and Play Effects on Shielding Players
public class Shielding : MonoBehaviour
{
    public GameObject impactEffect;
    // Exclusive Effect for Rays
    public GameObject bigRayEffect;
    public float impactTick = 0.15f;
    // Shake Camera on Big Impact
    CamShake camShaker;

    void Start() {
        GameObject mainCam = GameObject.FindWithTag("MainCamera");

        if (mainCam != null) {
            camShaker = mainCam.GetComponent<CamShake>();
        } else {
            Debug.Log("No camera found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // On Shielding Bullets
        if (other.gameObject.tag == "EnemyShot") {
            // Instantiate Special Effect (Visuals + Sounds)
            GameObject impact = Instantiate(
                impactEffect,
                other.gameObject.transform.position,
                Quaternion.identity);
            // Cleaning up
            Destroy(other.gameObject);
            Destroy(impact, impactTick);
        }
        // On Contacting Ray Attack
        if (other.gameObject.tag == "DeathRay") {
            Debug.Log("Ray Touched!");
            GameObject rayImpact = Instantiate(
                bigRayEffect,
                other.bounds.ClosestPoint(gameObject.transform.position),
                Quaternion.identity
            );
            camShaker.StartShaking();
            Destroy(rayImpact, impactTick);
        }
    }
}

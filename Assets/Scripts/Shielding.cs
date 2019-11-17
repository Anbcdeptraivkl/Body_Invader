using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielding : MonoBehaviour
{
    public GameObject impactEffect;
    public float impactTick = 0.15f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "EnemyShot") {
            // Instantiate Special Effect (Visuals + Sounds)
            GameObject impact = Instantiate(
                impactEffect,
                other.transform.position,
                Quaternion.identity);

            // Cleaning up
            Destroy(other.gameObject);
            Destroy(impact, impactTick);
        }    
    }
}

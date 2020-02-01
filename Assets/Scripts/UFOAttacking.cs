using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* UFO in Tri-UFO Weapon Attacks */
public class UFOAttacking: MonoBehaviour {
    public GameObject enemyShot;
    public Transform shotSpawn;

    public float shotSpeed = 5;
    public float startDelay = 0.5f;
    public float timeShoot  = 1.5f;
    GameObject playerRef;

    void Start() {
        StartCoroutine("AutoShoot");
    }

    IEnumerator AutoShoot() {
        yield return new WaitForSeconds(startDelay);
        while (gameObject.activeInHierarchy) {
            playerRef = GameObject.FindWithTag("Player");
            if (!playerRef) {
                Debug.Log("Player not found");
                yield break;
            }
            GenerateShot();
            yield return new WaitForSeconds(timeShoot);
        }
    }

    void GenerateShot() {
        // Get Player Directions
        Vector2 shootingDir = (playerRef.transform.position - transform.position).normalized;

        // Instantiate and set Velocity:
        GameObject shot = Instantiate(enemyShot, shotSpawn.position, Quaternion.identity);
        // Velocitu:
        Vector2 shotVelocity = new Vector2(shootingDir.x * shotSpeed, shootingDir.y * shotSpeed);

        shot.gameObject.GetComponent<Rigidbody2D>().velocity = shotVelocity;
    }
}
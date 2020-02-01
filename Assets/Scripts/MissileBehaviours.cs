using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moving + Affecting Enemies + Player + UI:
public class MissileBehaviours: MonoBehaviour {
    public float movingTime = 1.5f;
    public float timeBtwSteps = 0.25f;

    public GameObject rocketExplosion;
    public AudioSource rocketExplodeSound;
    public float rocketDmg = 10;

    CamShake camShaker;
    // Center point of the Screen in 2D Viewport:
    Vector3 destination = new Vector3(0, 0, 0);

    void Start() {
        // Getting camera components:
        GameObject mainCam = GameObject.FindWithTag("MainCamera");

        if (mainCam != null) {
            camShaker = mainCam.GetComponent<CamShake>();
        } else {
            Debug.Log("No camera found.");
        }

        // Rotate:
        RotateTowardCenter();

        // Act:
        StartCoroutine("StepByStepBehaviour");
    }

    void RotateTowardCenter() {
        // Rotate toward facing Screen Center (Rotate around z):
        float angle = Mathf.Atan2(destination.y - transform.position.y, destination.x - transform.position.x) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, angle - 90);
    }

    IEnumerator StepByStepBehaviour() {
        // Wait for the Missile to fly to center with Coroutine:
        yield return StartCoroutine(MoveToCenter());

        Explode();

        // Hide the Visual Sprite
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(timeBtwSteps);

        // Cleaning with Self-destroy:
        Destroy(gameObject);
    }

    IEnumerator MoveToCenter() {
        float currentMoveTime = 0;

        Vector3 startPosition = transform.position;

        while (currentMoveTime < movingTime) {
            currentMoveTime += Time.deltaTime;

            gameObject.transform.position = 
                Vector3.Lerp(startPosition, destination, currentMoveTime / movingTime);

            yield return null;
        }

        yield break;
    }

    // Deal Dmgs to all visible enemies, and spawn Visual + Audio Effects (with Particles!)
    void Explode() {
        // Find all on-screen enemies:
        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");

        PlayExplosionEffects();

        foreach (GameObject enemy in enemiesArray) {
            // Deal 5 dmgs to all visible enemies:
            EnemyHPManager enemyHP = enemy.gameObject.GetComponent<EnemyHPManager>(); 
            enemyHP.DecreaseHP(rocketDmg);
        }     
    }

    // Visual (Particles Animation) + Sound Effects and Special Effects (Screen Shake)
    void PlayExplosionEffects() {
        // Paticle Animation
        GameObject mainExplosion = GameObject.Instantiate(
            rocketExplosion,
            transform.position,
            Quaternion.identity
        ) as GameObject;

        // Explosion SOund
        rocketExplodeSound.Play();

        camShaker.StartShaking(0.6f, 0.5f);

        // Self-cleaning
        Destroy(mainExplosion, 1.5f);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* UFO in Tri-UFO Weapon Attacks */
public class UFOAttacking: MonoBehaviour {
    public GameObject enemyShot;

    public Transform localRoot;
    public Transform shotSpawn;

    public float shotXSpeed = 5;
    public float shotYSpeed = 8;

    public float startDelay = 0.5f;
    public float timeShoot  = 1.2f;

    void Start() {
        StartCoroutine("AutoShoot");
    }

    IEnumerator AutoShoot() {
        yield return new WaitForSeconds(startDelay);
        
        while (true) {
            GenerateShot();

            yield return new WaitForSeconds(timeShoot);
        }
    }

    void GenerateShot() {
        // Instantiate and set Velocity:
        GameObject shot = Instantiate(enemyShot, shotSpawn.position, Quaternion.identity);

        // Velocitu:
        Vector2 headingVector = shotSpawn.position - localRoot.position;
        Vector2 distance = headingVector / headingVector.magnitude;

        Vector2 shotVelocity = new Vector2(
            distance.x * shotXSpeed,
            distance.y * shotYSpeed);

        shot.gameObject.GetComponent<Rigidbody2D>().velocity = shotVelocity;
    }
}
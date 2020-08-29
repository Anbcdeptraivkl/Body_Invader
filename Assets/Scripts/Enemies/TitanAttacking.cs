using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Attacking Patterns of the Titan:
public class TitanAttacking: MonoBehaviour {
    public float yVelocity;
    public float xVelocity;

    public GameObject shot;

    public Transform[] shotSpawnCollection;


    public int numOfShotWaves = 1;
    public float startDelay;
    public float turnDelay;
    public float delayBtwShotWave;
    // Boss Reference
    Boss self;


    void Start() {
        self = gameObject.GetComponent<Boss>();
        StartCoroutine("Attack");
    }

    
    IEnumerator Attack() {
        yield return new WaitForSeconds(startDelay);

        // Continously Attack while alive:
        while (!self.IsDying()) {
            // Waves of Shots:
            for (int i = 0; i < numOfShotWaves; i++) {
                TripleShoot();
                yield return new WaitForSeconds(delayBtwShotWave);
            }

            // Wait for next shooting turn:
            yield return new WaitForSeconds(turnDelay);
        }
    }

    void TripleShoot() {
        foreach (Transform spawn in shotSpawnCollection) {
            GameObject lShot, midShot, rShot;

            lShot = MakeShot(spawn, new Vector2(-xVelocity, yVelocity));
            midShot = MakeShot(spawn, new Vector2(0, yVelocity));
            rShot = MakeShot(spawn, new Vector2(xVelocity, yVelocity));
        }
    }

    GameObject MakeShot(Transform spawn, Vector2 velocity) {
        GameObject tempShot = Instantiate(shot, spawn.position, Quaternion.identity) as GameObject;

        tempShot.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y);

        return tempShot;
    }
}
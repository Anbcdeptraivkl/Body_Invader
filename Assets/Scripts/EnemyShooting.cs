using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy shooting routine: with shots velocity + rotation setting and all:
// (the shots themselves are static and will be launched by the Component)
public class EnemyShooting: MonoBehaviour {
    public GameObject shot;

    [Tooltip("Base x speed, values greater than 0 only")]
    public float xSpeed;

    public float ySpeed;

    public Transform shotSpawn;

    public float fireDelay = 0.5f;

    public float fireRate = 0.5f;

    Vector3 velocity;

    void Start() {
        float relativeXSpeed = (transform.position.x < 0) ? xSpeed : -xSpeed;
        velocity = new Vector3(relativeXSpeed, ySpeed, 0);

        InvokeRepeating("Shoot", fireDelay, fireRate);
    }

    void Shoot() {
        //Instantiate the shot object with its rotation, then set its velocity:
        GameObject spawnedShot = Instantiate(
            shot,
            shotSpawn.position,
            Quaternion.identity
        ) as GameObject;

        spawnedShot.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        spawnedShot.gameObject.transform.rotation = Quaternion.LookRotation(velocity);
    }
}
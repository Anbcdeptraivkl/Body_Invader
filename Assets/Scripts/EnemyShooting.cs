using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy shooting routine: with shots velocity + rotation setting and all:
// (the shots themselves are static and will be launched by the Component)
public class EnemyShooting: MonoBehaviour {
    public GameObject shot;

    public float xSpeed;

    public float ySpeed;

    public Transform shotSpawn;

    public float fireDelay;

    public float fireRate;

    Vector2 velocity2D;

    void Start() {
        xSpeed = transform.position.x >= 0 ? -xSpeed : xSpeed;
        
        velocity2D = new Vector2(xSpeed, ySpeed);

        InvokeRepeating("Shoot", fireDelay, fireRate);
    }

    void Shoot() {
        //Instantiate the shot object with its rotation, then set its velocity:
        GameObject spawnedShot = Instantiate(
            shot,
            shotSpawn.position,
            Quaternion.identity
        ) as GameObject;

        spawnedShot.gameObject.GetComponent<Rigidbody2D>().velocity = velocity2D;

        // Set the sprite rotation toward the velocity direction:
        float angle = Mathf.Atan2(xSpeed, ySpeed) * Mathf.Rad2Deg;
        // spawnedShot.gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
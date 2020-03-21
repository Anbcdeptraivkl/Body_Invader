using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* The Enemy Object will slowly rotate toward player (including the shot spawns and direction vectors)*/
/* After each rotating routine, the enemy will begin shooting */
public class TrackerTracking: MonoBehaviour 
{
    public float rotateRate;
    public float rotateDelay;
    public float startDelay;

    public GameObject trackShot;
    [SerializeField]
    public Transform[] shotSpawns;
    public float shotSpeed;
    public float shootingDelay;

    Quaternion targetRotation;

    Transform playerTransform;

    float lerpRate;


    void Start () {
        StartCoroutine("Track");
    }

    IEnumerator Track() {
        // Wait for the initial movement to finish
        yield return new WaitForSeconds(startDelay);
        // When Alive
        while (true) {
           //Shoot after rotating! 
            yield return StartCoroutine(SpawnDoubleShot());
            yield return StartCoroutine(RotateRoutine());
        }
        // Get the relative rotation from player to host enemy:
    }

    IEnumerator RotateRoutine() {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj) {

            playerTransform = playerObj.transform;
        }
        else {
            Debug.Log("Player not found or destroyed");
            yield break;
        }

        if (!playerTransform) {
            yield break;
        }

        //Rotate around the z as upward axis:
        // Getting Rotate direction
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        targetRotation = Quaternion.LookRotation(direction, Vector3.forward);
        targetRotation.x = 0.0f;
        targetRotation.y = 0.0f;

        do {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateRate * Time.deltaTime);
            yield return null;
        } while (
            // Checking for the current direction
            Vector3.Angle(transform.up, direction) > 1 &&
            Vector3.Angle(transform.up, direction) < 179);

        yield return new WaitForSeconds(rotateDelay);
    }

    IEnumerator SpawnDoubleShot() {
        // Suverted y axis for directions:
        Vector3 velocityDirection = -transform.up;
        Vector3 shotVelocity = velocityDirection * shotSpeed;
        
        // Instantiate with adopted position and rotation + velocity:
        for (int i = 0; i < 2; ++i) {
            foreach(Transform spawn in shotSpawns) {
                GameObject spawnedShot = Instantiate(
                    trackShot,
                    spawn.position,
                    transform.rotation
                ) as GameObject;
                spawnedShot.GetComponent<Rigidbody2D>().velocity = shotVelocity;       
            }
            yield return new WaitForSeconds(shootingDelay);
        }
        yield break;
    }
}
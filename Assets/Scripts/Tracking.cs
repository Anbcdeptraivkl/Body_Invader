using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* The Enemy Object will slowly rotate toward player (including the shot spawns and direction vectors)*/
/* After each rotating routine, the enemy will begin shooting */

public class Tracking: MonoBehaviour 
{

    public float rotateRate;
    public float rotateDelay;
    public float startDelay;

    public GameObject shot;
    public Transform shotSpawn;
    public float shotSpeed;
    public float shootingDelay;



    Quaternion targetRotation;

    Transform playerTransform;

    float rate;


    void Start () {
        StartCoroutine("Track");
    }

    IEnumerator Track() {

        yield return new WaitForSeconds(startDelay);

        while (true) {

            
           //Shoot after rotating! 
            yield return StartCoroutine("SpawnDoubleShot");

            playerTransform = GameObject.FindWithTag("Player").transform;

            if (!playerTransform) {
                yield return null;
            }

            //Rotate around the z as upward axis:
           targetRotation = 
                Quaternion.LookRotation(playerTransform.position - transform.position, Vector3.forward);

            targetRotation.x = 0.0f;
            targetRotation.y = 0.0f;

            //Fixed Time rotate strength, limited at 1 max:
            rate = Mathf.Min(rotateRate*Time.deltaTime, 1);

            yield return new WaitForSeconds(rotateDelay);
        }
        // Get the relative rotation from player to host enemy:
    }

    void LateUpdate() {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rate);
    }

    IEnumerator SpawnDoubleShot() {

        // Suverted y axis for directions:
        Vector3 velocityDirection = -transform.up;
        Vector3 shotVelocity = velocityDirection * shotSpeed;

        // Set velocity:
        
        // Instantiate with adopted position and rotation + velocity:
        for (int i = 0; i < 2; ++i) {
            GameObject spawnedShot = Instantiate(
                shot,
                shotSpawn.position,
                transform.rotation
            ) as GameObject;

            spawnedShot.GetComponent<Rigidbody2D>().velocity = shotVelocity;       

            yield return new WaitForSeconds(shootingDelay);
        }

        
        yield break;
    }
}
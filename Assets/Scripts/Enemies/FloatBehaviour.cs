using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Moving down, then Shooting while Floating Up and Down, Left and Right -> All Movements are Done Consistently with Animations */
/* Shoot Turning + Spread Bullets*/
public class FloatBehaviour: MonoBehaviour {
    public GameObject shotPrefab;
    public Transform spawnPoint;
    public float shootStartDelay;
    public float shootInterval;

    void Start() {

    }

    // Wait for Animator States to reach the Floating Loops using Animation Events (At the Start of the Animation Clip)
    // Start Shooting

    // SHooting Interval Coroutine
    IEnumerator Shoot() {
        yield return new WaitForSeconds(shootStartDelay);
        // Keep shooting as long as the agent is alive
        while (true) {
            Instantiate(
                shotPrefab,
                spawnPoint.position,
                Quaternion.identity);

            yield return new WaitForSeconds(shootInterval);
        }
    }

}
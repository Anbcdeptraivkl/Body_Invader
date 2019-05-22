using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Control the Player attacking behaviours and upgrades:

[System.Serializable]

public class PlayerAutoShooting: MonoBehaviour {
    
    public GameObject shot;
    public GameObject strongShot;

    public Transform shotSpawn;
    public float delayTime;
    public float fireRate;

    bool strongShooting = false;

    void Start()
    {
                 

            InvokeRepeating("Fire", delayTime, fireRate);

    }

    private void Fire()
    {
        //Check if yu have shooting Upgrades:
        if (strongShooting) {

            FireStrong();

        } else {
            // Normal shooting:
            //No rotation, only speed!
            Instantiate(shot, shotSpawn.position, Quaternion.identity);

        }
    }

    private void FireStrong() {

        Instantiate(strongShot, shotSpawn.position, Quaternion.identity);

    }

    public void StartStrongShooting() {
        strongShooting = true;
    }

    public void StopStrongShooting() {
        strongShooting = false;
    }
}
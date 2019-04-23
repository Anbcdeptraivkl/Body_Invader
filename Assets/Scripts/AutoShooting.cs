using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class AutoShooting: MonoBehaviour {
    
    public GameObject shot;
    public Transform shotSpawn;
    public float delayTime;
    public float fireRate;

    void Start()
    {
        InvokeRepeating("Fire", delayTime, fireRate);
    }

    private void Fire()
    {
        //No rotation, only speed!
        Instantiate(shot, shotSpawn.position, Quaternion.identity);
    }
}
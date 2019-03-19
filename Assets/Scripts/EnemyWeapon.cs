using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Enemy SHooting projectiles overtime */
public class EnemyWeapon : MonoBehaviour
{
    public GameObject enemyShot;
    public Transform shotSpawn;
    public float delayTime;
    public float fireRate;

    void Start()
    {
        InvokeRepeating("Fire", delayTime, fireRate);
    }

    private void Fire()
    {
        Instantiate(enemyShot, shotSpawn.position, shotSpawn.rotation);
    }
}

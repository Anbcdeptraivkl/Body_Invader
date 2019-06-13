using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Control the Player attacking behaviours and upgrades:

[System.Serializable]

public class PlayerAutoShooting: MonoBehaviour {
    
    // Shot and Upgrades Collections:
    // Utilize Prefabs, nested Prefabs and Linking Prefabs for the most effective methods:
    [System.Serializable]
    public struct Shot {
        public GameObject shotObj;
        public int upgradeLevel;
    }

    public List<Shot> shotList = new List<Shot>();

    public Transform shotSpawn;
    public float delayTime;
    public float fireRate;

    GameObject shot;

    int shotLevel;


    void Start()
    {
            // Initiate the Starting weapons:
            shotLevel = 0;
            shot = shotList[shotLevel].shotObj;

            InvokeRepeating("Fire", delayTime, fireRate);

    }

    public void ShotUpgrade() {
        // Increase shot level and re-assign the weapons when receiving upgrades:
        if (shotLevel + 1 < shotList.Count) {
            shotLevel++;
            shot = shotList[shotLevel].shotObj;
        }
    }

    public void ShotDowngrade() {
        // Decrease Shot Levels on Negative Effects of Enemies:
        shotLevel--;
        shot = shotList[shotLevel].shotObj;
    }

    public int GetWeaponLevel() {
        return shotLevel;
    }

    private void Fire()
    {
        // Normal shooting:
        //No rotation, only speed!
        Instantiate(shot, shotSpawn.position, Quaternion.identity);
    }

}
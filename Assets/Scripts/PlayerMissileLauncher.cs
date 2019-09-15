using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Player Missile Manager and Controller:
public class PlayerMissileLauncher: MonoBehaviour {
    public Text missileCount;
    public GameObject missileObj;

    static int missileAmount;


    void Start() {
        missileAmount = 0;
    }

    void Update() {
        missileCount.text = missileAmount.ToString();

        // Handling Missile Launching Events:
        LaunchingUpdate();
    }

    public int GetMissileCount() {
        return missileAmount;
    }

    public void IncreaseMissile(int amount = 1) {
        missileAmount += amount;
    }

    void LaunchingUpdate() {
        // Update with Input Event:
        if (Input.GetKeyDown(KeyCode.LeftControl) && 
            missileAmount > 0) 
        {
            Launch();
            Debug.Log("Shoot a Missile");
        }
    }

    void Launch() {
        // Launch Missile, one at a time:
        Instantiate(
            missileObj,
            gameObject.transform.position,
            Quaternion.identity);
        
        // Deplete Missile Count (unsigned!):
        if (missileAmount > 0)
            missileAmount--;
    }
}
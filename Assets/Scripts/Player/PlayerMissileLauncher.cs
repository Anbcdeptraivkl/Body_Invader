using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Player Missile Manager and Controller:
public class PlayerMissileLauncher: MonoBehaviour {
    public Text missileCount;
    public GameObject missileObj;

    static int missileAmount;
    private int pointThreshold;


    void Start() {
        GameObject controller = GameObject.FindWithTag("GameController");

        missileAmount = 0;

        pointThreshold = 300;
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

        PlayGettingSound();
    }

    void LaunchingUpdate() {
        // Update with Input Event:
        if (Input.GetKeyDown(KeyCode.LeftControl) && 
            missileAmount > 0) 
        {
            Launch();
            Debug.Log("Shot a Missile!");
        }
    }

    void Launch() {
        // Launch Missile, one at a time:
        Instantiate(
            missileObj,
            gameObject.transform.position,
            Quaternion.identity);

        PlayLaunchingEffects();
        
        // Deplete Missile Count (unsigned!):
        missileAmount--;
    }

    //Effects for Getting New Missiles: Sound and Flashing Visuals
    void PlayGettingSound() {

    }

    // Immersive Shooting Effects:
    void PlayLaunchingEffects() {

    }
}
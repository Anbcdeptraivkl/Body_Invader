using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Upgrades System for Plyaer Ships that use Charge Gun (the Default Weapon Type): 
//  - Attach as Component to the Player Prefab
//  - All the Weapon Behaviours and Properties are Unique to each Weapons and therefor are Keep Seperated from the Main Player Component (just like Missile Component)
//  - Will be Abstracted when New Weapons are added to the Arsenal
public class PlayerChargeWeapon: MonoBehaviour {
    // References
    Player player;

    [Header("Attacks")]
    public List<GameObject> shotList = new List<GameObject>();
    public Transform shotSpawn;
    [SerializeField]
    float fireRate = 0.25f;

    [Header("Charger")]
    public Image chargeBar;
    [SerializeField]
    int chargingValue = 0;
    [SerializeField]
    int nextChargeGoal = 10;
    [SerializeField]
    int nextChargeStep = 10;
    float shootDelayTime = 0.0f;
    int shotLevel;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
         // Initiate the Starting weapons:
        shotLevel = 0;
    }

    void Update() {
        if (player.Controllable()) {
            ShootingUpdate();
        }
    }

    // Charge Everytime you destroy an Enemy (including Mini-bosses)
    public void Charge(int charge = 1) {
        chargingValue += charge;
        if (chargingValue >= nextChargeGoal) {
            Upgrade();
        }
        ChargeBarUpdate();
    }

    public int GetWeaponLevel() {
        return shotLevel;
    }

    /* ATTACKING MECHANICS AND CONTROLLERS */
    private void Fire()
    {
        // Normal shooting:
        //No rotation, only speed!
        Instantiate(shotList[shotLevel], shotSpawn.position, Quaternion.identity);
    }

    // Shooting Loop
    void ShootingUpdate() {
        // Fixed time Step Mechanics: Delay and Frie Rate contribute to the overall firing speed:
        shootDelayTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && shootDelayTime > fireRate) {
            Fire();
            // Reset the time step and start the new iteration:
            shootDelayTime = 0.0f;
        }
    }

    void Upgrade() {
        // Only Upgrades if there are sufficient new Levels
        if (shotLevel < (shotList.Count - 1)) {
            shotLevel++;
        }
        chargingValue = 0;
        nextChargeGoal += nextChargeStep;
    }

    void ChargeBarUpdate() {
        float currentFill = (float)Math.Round((float)chargingValue / nextChargeGoal, 1);
        chargeBar.fillAmount = currentFill;
    }
}
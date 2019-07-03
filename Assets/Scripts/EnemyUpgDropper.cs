using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The enemies will sometimes Drop Upgrade when Destroyed
// This is the controller for this behaviour:

public class EnemyUpgDropper: MonoBehaviour {

    //Strcut storing Upgrade Prefabs data:
    [System.Serializable]
    public struct Upgrade {
        public string name;
        public GameObject upgradeObj;
        public float rarity;
    }

    public List<Upgrade> upgradeList = new List<Upgrade>();

    public float dropChance;


    public void CalculateDrop() {

        float chance = Random.Range(0, 100) + 1; //the 0 is inclusive, while 100 is excluded

        if (chance <= dropChance) {
            DropUpgrade();
        }
    }

    void DropUpgrade() {

        // The total Drop Weight and the random drop rate::
        float dropWeight = 0;

        for (int i = 0; i < upgradeList.Count; ++i) {
            dropWeight += upgradeList[i].rarity;
        }

        float rate = Random.Range(0, dropWeight) + 1;

        
        // Cycle through the list again to determine which upgrades will drop::
        for (int j = 0; j < upgradeList.Count; ++j) {

            // If in-range, spawn and return, else decrease the rate and continue looping through other upgrades:
            if (rate < upgradeList[j].rarity) {
                
                Instantiate(
                    upgradeList[j].upgradeObj,
                    gameObject.transform.position,
                    Quaternion.identity
                );

                break;
            }

            rate -= upgradeList[j].rarity;
        }
    }



}
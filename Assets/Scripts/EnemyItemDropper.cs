using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The enemies will sometimes Drop Upgrade when Destroyed
// This is the controller for this behaviour:

public class EnemyItemDropper: MonoBehaviour {

    //Strcut storing Upgrade Prefabs data:
    [System.Serializable]
    public struct DropItem {
        public string name;
        public GameObject obj;
        public float rarity;

        public int amount;
    }

    public List<DropItem> randomDropList= new List<DropItem>();
    public List<DropItem> persistentDropList = new List<DropItem>();

    public float dropChance;

    // Drop by chances:
    public void CalculateRandomDrop() {

        float chance = Random.Range(0, 100) + 1; //the 0 is inclusive, while 100 is excluded

        if (chance <= dropChance) {
            DropUpgrade();
        }
    }

    // Drop evertyime (custom amounts):
    public void DropPersistences() {
        // Checking if the List is empty:
        if (persistentDropList.Count <= 0) {
            Debug.Log("No persistent Drops from this object");
            return;
        }

        foreach (DropItem drop in persistentDropList) {
            // Dropping!
            for (int i = 0; i < drop.amount; i++) {
                Instantiate(
                    drop.obj,
                    transform.position,
                    Quaternion.identity);
            }
        }
    }

    void DropUpgrade() {

        // The total Drop Weight:
        float dropWeight = 0;

        for (int i = 0; i < randomDropList.Count; ++i) {
            dropWeight += randomDropList[i].rarity;
        }

        // Random drop rate:
        float rate = Random.Range(0, dropWeight) + 1;

        // Cycle through the list again to determine which upgrades will drop::
        for (int j = 0; j < randomDropList.Count; ++j) {
            // If in-range, spawn and return, else decrease the rate and continue looping through other upgrades:
            if (rate < randomDropList[j].rarity) {
                Instantiate(
                    randomDropList[j].obj,
                    gameObject.transform.position,
                    Quaternion.identity
                );
                break;
            }

            rate -= randomDropList[j].rarity;
        }
    }



}
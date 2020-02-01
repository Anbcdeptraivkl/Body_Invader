using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Spawn Enemies on Activated by Player Activate Box / Playing Zone */
public class EnemySpawnPoint: MonoBehaviour {
    public GameObject enemyPrefab;
    public uint amount = 0;

    public float delayFirst = 0;

    public float delayBtwEnemies = 0;

    // Activate on Touching Playing Zone
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("ActivateBox")) {
            StartCoroutine(SpawnEnemies());
        }    
    }

    IEnumerator SpawnEnemies() {
        yield return new WaitForSeconds(delayFirst);

        for (int i = 0; i < amount; i++) {
            Instantiate(
                enemyPrefab,
                transform.position,
                Quaternion.identity);

            yield return new WaitForSeconds(delayBtwEnemies);
        }
    }
    
}
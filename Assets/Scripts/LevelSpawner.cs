using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner: MonoBehaviour {
    //Spawn References:
    public float spawnDelay;
    public float waveStartDelay;
    public float waveSpawnDelay;

    [System.Serializable]
    public struct EnemyFormation {
        Enemy enemy;
        Transform spawnPosition;
    }

    List<EnemyFormation> formation = new List<EnemyFormation>();

    SpawnManager spawnMng;

    void Start() {
        spawnMng = gameObject.GetComponent<SpawnManager>();
    }

    IEnumerator SpawnWaves() {
        while(spawnMng.SpawningCheck()) {

            Debug.Log("Spawning");

            //Start Delay:
            yield return new WaitForSeconds(waveStartDelay);

            
        }
    }



}
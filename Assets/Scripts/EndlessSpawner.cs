using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Endless Random SPawning COmponent:
public class EndlessSpawner : MonoBehaviour
{

    public int enemiesPerWave;
    //Spawn References:
    public float spawnDelay;
    public float waveStartDelay;
    public float waveSpawnDelay;

    SpawnManager spawnMng;


    // Start is called before the first frame update
    void Start()
    {
        spawnMng = GetComponent<SpawnManager>();

        StartCoroutine("SpawnWaves");
    }
    

    IEnumerator SpawnWaves() {
        while(spawnMng.SpawningCheck()) {

            Debug.Log("Spawning");

            //Start Delay:
            yield return new WaitForSeconds(waveStartDelay);

            for (int i = 0; i < enemiesPerWave; ++i) {

                spawnMng.RandomSpawn();

                //Delay between Spawn
                yield return new WaitForSeconds(spawnDelay);
            }

            yield return new WaitForSeconds(waveSpawnDelay);
        }
    }

    void Spawn() {

    }
}

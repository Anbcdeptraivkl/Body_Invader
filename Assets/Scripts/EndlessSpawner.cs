using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    enum SpawnType {
        Easy,
        MultipleEasy,

        Normal
    }

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

                SpawnType type = RandomizeSpawnType();

                switch (type)
                {
                    case SpawnType.Easy: {
                        spawnMng.Spawn(SpawnManager.EnemyLevel.Easy);
                        break;
                    }

                    case SpawnType.MultipleEasy: {
                        spawnMng.Spawn(SpawnManager.EnemyLevel.Multiple);
                        break;
                    }

                    case SpawnType.Normal: {
                        spawnMng.Spawn(SpawnManager.EnemyLevel.Normal);
                        break;
                    }
                    
                }

                //Delay between Spawn
                yield return new WaitForSeconds(spawnDelay);
            }

            yield return new WaitForSeconds(waveSpawnDelay);
        }
    }

    SpawnType RandomizeSpawnType() {
        float easyProb = 0.5f;
        float multipleProb = 0.3f;

        // float hardProb = 0.1f;

        float spawnChance;
        spawnChance = Random.value;

        if (spawnChance < easyProb) {
            return SpawnType.Easy;
        } 
        else if (spawnChance < (easyProb + multipleProb)) {
            return SpawnType.MultipleEasy;
        } 
        else {
            return SpawnType.Normal;
        } 
    }
}

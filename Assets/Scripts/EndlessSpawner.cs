using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    enum SpawnType {
        Easy,
        MultipleEasy,

        Normal,
        Hard
    }

    public int enemiesPerWave;
    //Spawn References:
    public float spawnDelay;
    public float waveStartDelay;
    public float waveSpawnDelay;
    
    int difficulty;
    int wavesNumber;

    SpawnManager spawnMng;
    // Start is called before the first frame update
    void Start()
    {
        spawnMng = GetComponent<SpawnManager>();

        difficulty = 0;
        wavesNumber = 0;

        StartCoroutine("SpawnWaves");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWaves() {
        while(spawnMng.SpawningCheck()) {

            //Start Delay:
            yield return new WaitForSeconds(waveStartDelay);

            for (int i = 0; i < enemiesPerWave; ++i) {

                SpawnType type = RandomizeSpawnType();

                switch (type)
                {
                    case SpawnType.Easy: {
                        spawnMng.SpawnSingle(SpawnManager.EnemyLevel.Easy);
                        break;
                    }

                    case SpawnType.MultipleEasy: {
                        spawnMng.SpawnColumn(SpawnManager.EnemyLevel.Easy, 3);
                        break;
                    }

                    case SpawnType.Normal: {
                        spawnMng.SpawnSingle(SpawnManager.EnemyLevel.Normal);
                        break;
                    }
                    
                    case SpawnType.Hard: {
                        spawnMng.SpawnSingle(SpawnManager.EnemyLevel.Hard);
                        break;
                    }
                }

                //Delay between Spawn
                yield return new WaitForSeconds(spawnDelay);
            }

            // Increase waves Spawned number and Wait for new wave:
            wavesNumber++;
            yield return new WaitForSeconds(waveSpawnDelay);
        }
    }

    SpawnType RandomizeSpawnType() {
        float easyProb = 0.4f;
        float multipleProb = 0.3f;
        float normalProb = 0.2f;

        // float hardProb = 0.1f;

        float spawnChance;
        spawnChance = Random.value;

        if (spawnChance < easyProb) {
            return SpawnType.Easy;
        } 
        else if (spawnChance < (easyProb + multipleProb)) {
            return SpawnType.MultipleEasy;
        } 
        else if (spawnChance < (easyProb + multipleProb + normalProb)) {
            return SpawnType.Normal;
        } 
        else {
            return SpawnType.Hard;
        }
    }
}

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

    // Spawn Manager ref:
    SpawnManager s;

    // Total weight for caluculating random Spawn Chances:
    float totalWeight;


    // Start is called before the first frame update
    void Start()
    {
        // Reference the Spawn Manager:
        s = GameObject.FindWithTag("GameController").GetComponent<SpawnManager>();
        
        // The total of all units's spawn rates will be add up to get total weight for random calculation in later Random Spawning Methods:
        CalculateTotalWeight();

        StartCoroutine("SpawnWaves");
    }
    

    IEnumerator SpawnWaves() {
        while(s.SpawningCheck()) {

            //Start Delay:
            yield return new WaitForSeconds(waveStartDelay);

            for (int i = 0; i < enemiesPerWave; ++i) {

                RandomSpawn();

                //Delay between Spawn
                yield return new WaitForSeconds(spawnDelay);
            }

            yield return new WaitForSeconds(waveSpawnDelay);
        }
    }

    void RandomSpawn() {

        //Calculate the weight,items by items and substracting the weight until, the rate lower than the random value generated will be the one spawned:

        // Random Rate:
        float randomRate = Random.Range(0, totalWeight);

        foreach (Enemy Enemy in s.EnemyList) {

            if (Enemy.spawnRate >= randomRate) {
                // Check for spawn direction, and consequently the spawn positions:
                Transform spawnPoint = DetermineRandomSpawnDirection(Enemy);

                // For LEft and right Brute: Spawn multiple (3) in a row:
                if (Enemy.name == "BruteL" || Enemy.name == "BruteR") {
                    StartCoroutine(s.SpawnMulti(Enemy.name, spawnPoint, 3));
                } else {
                    s.SpawnSingle(Enemy.name, spawnPoint);
                }

                return;

            } else {
                randomRate -= Enemy.spawnRate;
            }

        }

    }

    void CalculateTotalWeight() {
        // Calculate total Spawn Weight of all element in collections:
        totalWeight = 0;

        foreach (Enemy Enemy in s.EnemyList) {
            totalWeight += Enemy.spawnRate;
        }
    }

    Transform DetermineRandomSpawnDirection(Enemy enemy) {
        // Check for spawn direction, and consequently the spawn positions:
        // Random position from the Spawn Points Cllections:
        Transform randomStraightPoint = s.spawnPositionRange[(int)Random.Range(0, s.spawnPositionRange.Length -1)];
        Transform randomLeftPoint = s.leftSpawnPoints[(int)Random.Range(0, s.leftSpawnPoints.Length - 1)];
        Transform randomRightPoint = s.rightSpawnPoints[(int)Random.Range(0, s.rightSpawnPoints.Length - 1)];

        // Checking and Assigning:
        Transform spawnPoint;

        switch (enemy.direction) {
            case SpawnDirection.Left: {
                spawnPoint = randomLeftPoint;
            }
            break;

            case SpawnDirection.Right: {
                spawnPoint = randomRightPoint;
            }
            break;

            default: {
                spawnPoint = randomStraightPoint;
            }
            break;
        }

        return spawnPoint;
    }
}

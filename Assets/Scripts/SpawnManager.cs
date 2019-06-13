using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dynamic Abstracted Spawn System with both Random Spawning and pre-Designed ones:
// SPawning in: Straight - Left - Right and Difficulty: Easy to Super Hard:
public class SpawnManager : MonoBehaviour
{
    public enum Difficulty {
        Easy,
        Normal,
        Hard,
        Heroic
    }

    public enum SpawnDirection {
        Straight,
        Left,
        Right
    }

    [System.Serializable]
    public struct Enemy {
        public string name;

        public GameObject prefab;

        public float spawnRate;

        public Difficulty difficulty;

        public SpawnDirection direction;

    }

    

    public List<Enemy> EnemyList = new List<Enemy>();


    [SerializeField]
    public Transform[] spawnPositionRange;

    [SerializeField]
    public Transform[] leftSpawnPoints;

    [SerializeField]
    public Transform[] rightSpawnPoints;

    public float multiSpawnDelay;



    //Control Operations:
    GameOver gameOverRef;
    bool isSpawning;

    // Total weight for caluculating Spawn Chances:
    float totalWeight;

    int spawnedNum = 0;



    // Start is called before the first frame update
    void Start()
    {

        GameObject gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        gameOverRef = gameControllerObj.GetComponent<GameOver>();

        isSpawning = true;

        // Construct total weight for Spawning:
        CalculateTotalWeight();

    }

    public void RandomSpawn() {

        //Calculate the weight,items by items and substracting the weight until, the rate lower than the random value generated will be the one spawned:

        // Random Rate:
        float randomRate = Random.Range(0, totalWeight);

        foreach (Enemy Enemy in EnemyList) {

            if (Enemy.spawnRate >= randomRate) {
                // Check for spawn direction, and consequently the spawn positions:
                Transform spawnPoint = DetermineSpawnDirection(Enemy);

                // For LEft and right Brute: Spawn multiple (3) in a row:
                if (Enemy.name == "BruteL" || Enemy.name == "BruteR") {
                    StartCoroutine(SpawnMulti(Enemy.name, spawnPoint, 3));
                } else {
                    SpawnSingle(Enemy.name, spawnPoint);
                }

                Debug.Log("Spawned: " + (++spawnedNum));

                return;

            } else {
                randomRate -= Enemy.spawnRate;
            }

        }

    }

    Transform DetermineSpawnDirection(Enemy enemy) {
        // Check for spawn direction, and consequently the spawn positions:
        // Random position from the Spawn Points Cllections:
        Transform randomStraightPoint = spawnPositionRange[(int)Random.Range(0, spawnPositionRange.Length -1)];
        Transform randomLeftPoint = leftSpawnPoints[(int)Random.Range(0, leftSpawnPoints.Length - 1)];
        Transform randomRightPoint = rightSpawnPoints[(int)Random.Range(0, rightSpawnPoints.Length - 1)];

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

    void CalculateTotalWeight() {
        // Calculate total Spawn Weight of all element in collections:
        totalWeight = 0;

        foreach (Enemy Enemy in EnemyList) {
            totalWeight += Enemy.spawnRate;
        }
    }

    void SpawnSingle(string name, Transform spawnPoint) {
        // Find the right Enemy, and then instantiate them using the position of the transform point:
        Enemy spawningEnemy = EnemyList.Find(x => x.name == name);

        Instantiate(
            spawningEnemy.prefab,
            spawnPoint.position,
            Quaternion.identity
        );
    }

    IEnumerator SpawnMulti(string name, Transform spawnPoint, int amount) {
        // Spawn multiple enemies of the same kind in the row (in the same position and direction)
        for (int i = 0; i < amount; i++) {
            SpawnSingle(name, spawnPoint);

            yield return new WaitForSeconds(multiSpawnDelay);
        }
        yield break;
    }

    public bool SpawningCheck() {
        // Check if Game over or not, and stop spawning if over:
        isSpawning = !gameOverRef.CheckGameOver();
        
        return isSpawning;
    }

}

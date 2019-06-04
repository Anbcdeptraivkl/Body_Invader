using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dynamic Abstracted Spawn System with both Random Spawning and pre-Designed ones:
public class SpawnManager : MonoBehaviour
{
    public enum Difficulty {
        Easy,
        Normal,
        Hard,
        Heroic
    }

    [System.Serializable]
    public struct Enemy {
        public string name;

        public GameObject prefab;

        public float spawnRate;

    }

    public List<Enemy> enemyList = new List<Enemy>();


    [SerializeField]
    public Transform[] spawnPositionRange;


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

    }

    public void RandomSpawn() {

        CalculateTotalWeight();

        //Calculate the weight,items by items and substracting the weight until, the rate lower than the random value generated will be the one spawned:

        // Random Rate and Transform Position points:
        float randomRate = Random.Range(0, totalWeight);

        Transform randomPoint = spawnPositionRange[(int)Random.Range(0, spawnPositionRange.Length -1)];

        foreach (Enemy enemy in enemyList) {

            if (enemy.spawnRate >= randomRate) {
                SpawnSingle(enemy.name, randomPoint);

                Debug.Log("Spawned: " + (++spawnedNum));

                return;

            } else {
                randomRate -= enemy.spawnRate;
            }

        }

    }

    void CalculateTotalWeight() {
        // Calculate total Spawn Weight:
        totalWeight = 0;

        foreach (Enemy enemy in enemyList) {
            totalWeight += enemy.spawnRate;
        }
    }

    void SpawnSingle(string name, Transform spawnPoint) {
        // Find the right enemy, and then instantiate them using the position of the transform point:
        Enemy spawningEnemy = enemyList.Find(x => x.name == name);

        Instantiate(
            spawningEnemy.prefab,
            spawnPoint.position,
            Quaternion.identity
        );
    }

    public bool SpawningCheck() {

        // Check if Game over or not:
        isSpawning = !gameOverRef.CheckGameOver();
        
        return isSpawning;
    }

}

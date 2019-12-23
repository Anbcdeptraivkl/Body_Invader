using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dynamic Abstracted Spawn System with both Random Spawning and pre-Designed ones:
// SPawning in: Straight - Left - Right and Difficulty: Easy to Super Hard:
public enum Difficulty {
    Easy,
    Normal,
    Hard,
    Heroic,
    Boss
}

// The Direction that will be access when reading data to determine sawn positions:
public enum SpawnDirection {
    Top,
    Left,
    Right,
    Bottom
}


 [System.Serializable]
public struct Enemy {
    public string name;
    public GameObject prefab;
    // Spawn Rates for Random Spawning
    public float spawnRate;
    // Only for Endless Random Spawning:
    // Level Formation are designed in Data files:
    public Difficulty difficulty;
    public SpawnDirection direction;
}


public class SpawnManager : MonoBehaviour
{
    public List<Enemy> EnemyList = new List<Enemy>();

    [SerializeField]
    public Transform[] spawnPositionRange;

    [SerializeField]
    public Transform[] leftSpawnPoints;

    [SerializeField]
    public Transform[] rightSpawnPoints;

    public float multiSpawnDelay;

    //Control Operations to stop or continue spawning:
    GameOver gameOverRef;
    bool isSpawning;

    // Start is called before the first frame update
    void Start() {
        GameObject gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        gameOverRef = gameControllerObj.GetComponent<GameOver>();
        isSpawning = true;
    }

    public void SpawnSingle(string name, Transform spawnPoint) {
        // Find the right Enemy, and then instantiate them using the position of the transform point:
        Enemy spawningEnemy = EnemyList.Find(x => x.name == name);

        Instantiate(
            spawningEnemy.prefab,
            spawnPoint.position,
            Quaternion.identity
        );
    }

    // Preferred for Endless Spawning
    public IEnumerator SpawnMulti(string name, Transform spawnPoint, int amount) {
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

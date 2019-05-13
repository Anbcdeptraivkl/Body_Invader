using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public enum EnemyLevel {
        Easy,
        Normal,
        Multiple
    }

    //Enemies Prefabs (multiple Enemies per GameObjects)
    public GameObject easyEnemy;
    public GameObject normalEnemy;
    public GameObject easyString;
    private Dictionary<EnemyLevel, GameObject> Enemies = new Dictionary<EnemyLevel, GameObject>(3);

    
    public Vector3 spawnPositionRange;


    //Control Operations:
    GameOver gameOverRef;
    bool isSpawning;



    // Start is called before the first frame update
    void Start()
    {
        Enemies.Add(EnemyLevel.Easy, easyEnemy);
        Enemies.Add(EnemyLevel.Normal, normalEnemy);
        Enemies.Add(EnemyLevel.Multiple, easyString);

        GameObject gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        gameOverRef = gameControllerObj.GetComponent<GameOver>();

        isSpawning = true;

    }


    public void Spawn(EnemyLevel level) {

        Vector3 spawnPosition =
            spawnPosition = new Vector3(
            Random.Range(-spawnPositionRange.x, spawnPositionRange.x),
            spawnPositionRange.y,
            spawnPositionRange.z
            );
        
        Quaternion spawnQuarternion = Quaternion.identity;

        Instantiate(
            Enemies[level],
            spawnPosition,
            spawnQuarternion);

    }

    public bool SpawningCheck() {

        // Check if Game over or not:
        isSpawning = !gameOverRef.CheckGameOver();
        
        return isSpawning;
    }

}

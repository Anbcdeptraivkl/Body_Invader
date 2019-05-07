using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public enum EnemyLevel {
        Easy,
        Normal,
        Hard
    }

    //Enemies Prefabs (multiple Enemies per GameObjects)
    public GameObject easyEnemy;
    public GameObject normalEnemy;
    public GameObject hardEnemy;
    private Dictionary<EnemyLevel, GameObject> Enemies = new Dictionary<EnemyLevel, GameObject>(3);


    //Enemies Data:
    int spawnedEnemies;
    int activingEnemies;


    
    public Vector3 spawnPositionRange;


    //Control Operations:
    GameOver gameOverRef;
    bool isSpawning;



    // Start is called before the first frame update
    void Start()
    {
        Enemies.Add(EnemyLevel.Easy, easyEnemy);
        Enemies.Add(EnemyLevel.Normal, normalEnemy);
        Enemies.Add(EnemyLevel.Hard, hardEnemy);

        GameObject gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        gameOverRef = gameControllerObj.GetComponent<GameOver>();

        spawnedEnemies = 0;
        activingEnemies = 0;

        isSpawning = true;

    }


    public void SpawnSingle(EnemyLevel level) {

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

        spawnedEnemies++;
        activingEnemies++;
    }

    public void SpawnColumn(EnemyLevel level, int quantity) {

        float xPos = Random.Range(-spawnPositionRange.x, spawnPositionRange.x);

        for (int i = 0; i < quantity; ++i) {
            //Calculate position y in the comlumns of enemies using game object size and iterator:
            //The 1 number represent the space between enemies in the column:
            float spaceBetween = 0.8f;
            float yPos = spawnPositionRange.y + 
                spaceBetween +
                Enemies[level].GetComponent<Renderer>().bounds.size.y * i;

            Vector3 spawnPosition =
            spawnPosition = new Vector3(
                xPos,
                yPos,
                spawnPositionRange.z);

            Quaternion spawnQuarternion = Quaternion.identity;

            Instantiate(
                Enemies[level],
                spawnPosition,
                spawnQuarternion);

            spawnedEnemies++;
            activingEnemies++;
        }
    }


    public void EnemyDestroyed() {

        if (activingEnemies > 0) {
            activingEnemies--;
        }
    }

    public bool SpawningCheck() {

        isSpawning = gameOverRef.CheckGameOver();
        
        return isSpawning;
    }

    public int GetActiveEnemiesNum() {
        return activingEnemies;
    }
}

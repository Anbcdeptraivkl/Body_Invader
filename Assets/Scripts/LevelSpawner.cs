using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using UnityEngine;


// Enemy Data Structure:
// Wave Data (each) for storing parsed Level's Enemy Formations Data:
public struct SingleEnemyData {
    public string name;

    // The Directions and Positions will be parsed from Data files:
    public Transform spawnTransform;

    public int amount;
}

public class Wave {

    public void AddEnemyDataNode(string lName, Transform lSpawnTransform, int lAmount = 1) {
        SingleEnemyData tempEnemyNode = new SingleEnemyData();

        tempEnemyNode.name = lName;
        tempEnemyNode.spawnTransform = lSpawnTransform;
        tempEnemyNode.amount = lAmount;

        enemyDataList.Add(tempEnemyNode);
    }

    public void SetRestricted(bool rest) {
        restricted = rest;
    }

    public bool GetRestricted() {
        return restricted;
    }

    public void SetSyncStatus(bool sync) {
        syncing = sync;
    }

    public bool GetSyncStatus() {
        return syncing;
    }

    public List<SingleEnemyData> enemyDataList = new List<SingleEnemyData>();

    bool restricted;
    bool syncing;
}


// Reading Level-spcific data, then start spawning enemies in designed orders:
public class LevelSpawner: MonoBehaviour {

    // Text Asset Reference
    public TextAsset levelDataText;
    // Utility Data:
    public float delayBetweenWaves;
    public float delayPerEnemy;
    public int levelIndex;

    // Collection of Waves Data:
    List<Wave> waveDataList = new List<Wave>();

    //Spawn Data References:
    // Remember to initiate:
    XmlDocument levelDataDoc = new XmlDocument();

    // Wave Clearing status (for the Restricted);
    bool waveCleared;
    bool completed;

    // Base Spawner Components:
    SpawnManager s;


    void Start() {
        // Reference the Spawn Manager to get Common Properties and Methods:
        s = GameObject.FindWithTag("GameController").GetComponent<SpawnManager>();

        // Loading and Reading Data (from Resources Folder):
        levelDataDoc.LoadXml(levelDataText.text);
        ReadWavesData();

        // Start Spawning:
        Debug.Log("Start Spawning");

        StartCoroutine("SpawnWaves");

        waveCleared = false;

    }

    void Update() {
        // If the Waves are fully Cleared
        waveCleared = EnemyCount.Wiped();
    }

    // Read Data into Waves and Enemies's Data Collections and Structures:
    void ReadWavesData() {
        string wavesPath = "/Formation/Level[@index=\"" + levelIndex + "\"]/Wave";

        Debug.Log("Waves Data Path: " + wavesPath);

        XmlNodeList wavesNodeList = levelDataDoc.SelectNodes(wavesPath);

        // Abstraction Levels Extracting Data:
        // Waves:
        foreach (XmlElement wave in wavesNodeList) {
            // Temp Elements:
            Wave tempWave = new Wave();
            
            tempWave.SetRestricted(ExtractRestValue(wave));
            tempWave.SetSyncStatus(SetSyncWave(wave));
            // Enemies:
            foreach (XmlElement enemy in wave.ChildNodes) {
                // Getting the CHildren elements Data:
                string enemyName = enemy["Name"].InnerText;
                int positionIndex = int.Parse(enemy["PositionIndex"].InnerText);
                int amount = int.Parse(enemy["Amount"].InnerText);

                // Get Spawn Point by Direction:
                Transform enemySpawnPoint = GetTransformByDirection(enemyName, positionIndex);

                //Add Enemy Node, then continure iterating through the remaining Nodes:
                tempWave.AddEnemyDataNode(enemyName, enemySpawnPoint, amount);
            }

            // Adding the wave node into the Waves List after reading all enemy Data, then repeat for the nex wave node til the end of the level node:
            waveDataList.Add(tempWave);

            //After this loop statement, you Get the fully iterated waveDataList with full Enemy Data per Waves
        }
    }

    bool ExtractRestValue(XmlElement wave) {
         // Reading the Restricted attribute values for rested waves:
        string restStrValue = wave.Attributes["rest"].Value;
        bool restricted = string.Equals(restStrValue, "true", System.StringComparison.OrdinalIgnoreCase);
        return restricted;
    }

    bool SetSyncWave(XmlElement wave) {
        string syncStr = wave.Attributes["sync"].Value;
        bool sync = string.Equals(syncStr, "true", System.StringComparison.OrdinalIgnoreCase);
        return sync;
    }

    // Lv Spawn: The Father Spawn Fuction that call all other Functions to spawn the whole Level, waves by waves:
    IEnumerator SpawnWaves() {
        foreach (Wave wave in waveDataList) {
            // Check if Game Over:
            if(!s.SpawningCheck()) {
                break;
            }

            // Delay, then continue to iterate through the next Waves
            yield return new WaitForSeconds(delayBetweenWaves);

            // Sync Waves or not
            // Sync Symmetrical multi-Spawn
            if (wave.GetSyncStatus()) {
                // Loo[ by amount: in SYnc Waves, all Enemy groups are spawned with the same amount
                int syncAmount = wave.enemyDataList[0].amount;
                for (int i = 0; i < syncAmount; i++) {
                    // Spawn 1 of each Enemy Types
                    foreach (SingleEnemyData enemyData in wave.enemyDataList) {
                        s.SpawnSingle(enemyData.name, enemyData.spawnTransform);
                    }
                    yield return new WaitForSeconds(delayPerEnemy);
                }
            } else {
                // Spawn current Wave's enemies:
                foreach (SingleEnemyData enemyData in wave.enemyDataList) {
                    // Spawn 'amount' of enemies:
                    for (int i = 0; i < enemyData.amount; i++) {
                        s.SpawnSingle(enemyData.name, enemyData.spawnTransform);
                        yield return new WaitForSeconds(delayPerEnemy);
                    }
                }
            }

            // Wait for the enemies to be wiped out before spawning new (if the wave is restricted):
            if (wave.GetRestricted()) {
                yield return new WaitUntil(() => waveCleared == true);
            }
        }
        
        // End of level:
        completed = true;
        Debug.Log("Level Complete");
        
        yield break;
    }

    public bool LevelCompleteCheck() {
        return completed;
    }

    // Determine the Spawn Direction based on Enemy's name using the EnemyList collection:
    Transform GetTransformByDirection(string enemyName, int posIndex) {
        Enemy enemyNode = s.EnemyList.Find(x => x.name == enemyName);

        Transform spawnPoint;

        switch (enemyNode.direction) {
            case SpawnDirection.Left: {
                spawnPoint = s.leftSpawnPoints[posIndex];
            }
            break;

            case SpawnDirection.Right: {
                spawnPoint = s.rightSpawnPoints[posIndex];
            }
            break;

            // Default Top:
            default: {
                spawnPoint = s.spawnPositionRange[posIndex];
            }
            break;
        }

        return spawnPoint;
    }

    //Spawning Waves Coroutines

    


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Manage the number of spawned enemies on-scene:
public class EnemyCount: MonoBehaviour {
    private static int enemyCount = 0;

    void Awake() {
        enemyCount++;

        Debug.Log("Enemy Count:" + enemyCount);
    }

    void OnDestroy() {
        enemyCount--;

        Debug.Log("Enemy Count:" + enemyCount);
    }

    public static bool Wiped() {
        return enemyCount == 0;
    }

    public int GetCount() {
        return enemyCount;
    }
}
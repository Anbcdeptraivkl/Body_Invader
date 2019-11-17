using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Enemy Component: Represent and Manage the number of spawned enemies on-scene:
public class EnemyCount: MonoBehaviour {
    private static int enemyCount = 0;

    void Awake() {
        enemyCount++;
    }

    void OnDestroy() {
        enemyCount--;
    }

    public static bool Wiped() {
        return enemyCount == 0;
    }

    public int GetCount() {
        return enemyCount;
    }
}
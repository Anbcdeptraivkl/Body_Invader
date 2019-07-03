using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData: MonoBehaviour {
    private static int enemyCount = 0;

    void Awake() {
        enemyCount++;
    }

    void OnDestroy() {
        enemyCount--;
    }

    public int GetCount() {
        return enemyCount;
    }
}
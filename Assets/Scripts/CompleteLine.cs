using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Complete the Level on Player Object reaching the Finish (Goal) line*/
public class CompleteLine: MonoBehaviour {
    bool levelCompleted;

    void Start() {
        levelCompleted = false;
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            levelCompleted = true;
        }
    }

    public bool CheckLevelComplete() {
        return levelCompleted;
    }
}
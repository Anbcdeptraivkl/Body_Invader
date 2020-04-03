using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss: MonoBehaviour {
    // State Flags
    bool bossSpawned = false;

    // References
    
    BackgroundScrolling backScroll;

    void Start() {
        bossSpawned = true;
        // Stop Scrolling background when the Boss spawned
        backScroll = GameObject.FindWithTag("Background").GetComponent<BackgroundScrolling>();
        backScroll.StopScrolling();
    }

    void Update() {
        // Boss Behaviours
    }

    void OnDestroy() {
        // Win when the Boss is destroyed
        Debug.Log("Boss defeated!");
        LevelComplete.Win();
    }

    void BossBehaviours() {

    }
}
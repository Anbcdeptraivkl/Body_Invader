using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGettingShot: MonoBehaviour {
    private PlayerHPManager hpManager;

    void Start() {

        hpManager = GetComponent<PlayerHPManager>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "EnemyShot")
        {
            //Check for player Invincible frames before acting:
            if (!hpManager.CheckInvin()) {

                hpManager.DecreaseHp();

            }
            // Decreasing Player HP and Play effects:

            Destroy(other.gameObject);

        }
        
    }
}
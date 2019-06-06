using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shield Functionality: Blocking Enemies and Projectiles harmful to player, producing Effects and Points:
public class ShieldBlocking : MonoBehaviour
{
    public GameObject blockParticle;

    ScoreManager scoreMng;

    void Start() {
        GameObject controller = GameObject.FindWithTag("GameController");

        if (controller) {
            scoreMng = controller.GetComponent<ScoreManager>();
        } else {
            Debug.Log("Game Controller not Found");
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        
        if ( other.gameObject.tag == "EnemyShot" || 
            other.gameObject.tag == "Enemy") {
                //Instantiate the Exploding Effects (with audios)
                GameObject blockEffect = Instantiate(
                    blockParticle,
                    other.gameObject.transform.position,
                    Quaternion.identity
                ) as GameObject;

                // Destroy the Particles, and then the colliding object without affecting player:
                Destroy(blockEffect, 0.75f);

                Destroy(other.gameObject); 

                // Add 10 scores per blocks:
                scoreMng.UpdateScore(10);          
        }
    }
}

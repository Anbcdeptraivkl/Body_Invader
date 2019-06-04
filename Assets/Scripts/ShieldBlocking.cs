using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shield Functionality: Blocking Enemies and Projectiles harmful to player:
public class ShieldBlocking : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        
        if ( other.gameObject.tag == "EnemyShot" || 
            other.gameObject.tag == "Enemy") {
                Destroy(other.gameObject);           
        }
    }
}

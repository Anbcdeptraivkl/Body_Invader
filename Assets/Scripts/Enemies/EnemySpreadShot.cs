using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Behaviour for each single Shots in the Spread Shots Groups */
/* Can be reused for multiple Enemy Types */
public class EnemySpreadShot : MonoBehaviour {
    public Vector2 baseDirection;
    // Negative Speed to lead the Bullets down
    public float speed;

    Vector2 normalizedDir;
    Rigidbody2D rgbd2;

    // Start is called before the first frame update
    void Start() {
        // Setting Bullet's Speed
        rgbd2 = gameObject.GetComponent<Rigidbody2D>();
        // Get Direction
        normalizedDir = baseDirection.normalized;
        // Magnitude of Speed
        Vector2 bulletVlct = new Vector2(normalizedDir.x, normalizedDir.y) * speed;
        // Assigning
        rgbd2.velocity = bulletVlct;
    }

}

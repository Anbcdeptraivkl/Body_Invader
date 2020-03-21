using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Simple Continous, Straight line Movement for Enemy Prefabs*/
public class EnemyStraightMovement: MonoBehaviour {
    [SerializeField]
    float xSpeed = 0f;
    [SerializeField]
    float ySpeed = 0f;

    Rigidbody2D rgbd;

    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        rgbd.velocity = new Vector2 (xSpeed, ySpeed);
    }
}
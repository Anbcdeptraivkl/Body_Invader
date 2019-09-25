using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Straight Movement for Dropped Loots:
public class ShotSimpleMovement: MonoBehaviour {
    [SerializeField]
    float xSpeed = 0;

    [SerializeField]
    float ySpeed = 0;

    Rigidbody2D rgbd;

    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();

        Fly();
    }
    
    void Fly() {
        rgbd.velocity = new Vector2(xSpeed, ySpeed);
    }
}
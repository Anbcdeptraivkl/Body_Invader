using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Straight Movement for Dropped Loots:
public class DropStraightMovement: MonoBehaviour {
    [SerializeField]
    float xSpeed;

    [SerializeField]
    float ySpeed;

    [SerializeField]
    float delayFirst;

    Rigidbody2D rgbd;

    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();

        Invoke("SetMovement", delayFirst);
    }
    
    void SetMovement() {
        rgbd.velocity = new Vector2(xSpeed, ySpeed);
    }
}
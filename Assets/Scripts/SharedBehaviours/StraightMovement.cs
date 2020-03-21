using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Complete the Level on Player Object reaching the Finish (Goal) line*/
public class StraightMovement: MonoBehaviour {
    public float speedX;
    public float speedY;

    Rigidbody2D rgbd;

    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        if (rgbd) {
            rgbd.velocity = new Vector2(speedX, speedY);
        } else {
            Debug.Log("No Rigidbody found");
        }
    }
}
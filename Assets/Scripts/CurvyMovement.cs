using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvyMovement: MonoBehaviour {
    [SerializeField]
    float moveRate = 0f;

    [SerializeField]
    float directionInterval = 0f;
    [SerializeField]
    float intervalRate = 0f;

    [SerializeField]
    Vector2 startMovement = new Vector2(0, 0);

    //References
    Rigidbody2D rgbd;

    float moveInterval = 0f;
    Vector3 startPos;

    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        // Initial Movement Speed
        rgbd.velocity = startMovement;
        startPos = transform.position;
    }

    private void FixedUpdate() {
        // Moving and changing direction over many Stepped Delta time Intervals
        moveInterval += Time.deltaTime;
        if (moveInterval > intervalRate) {
            // Interval Direction and Lerp Velocity over Time
            Vector2 targetMovement = new Vector2(rgbd.velocity.x, rgbd.velocity.y + directionInterval);
            rgbd.velocity = Vector2.Lerp(rgbd.velocity, targetMovement, Time.deltaTime * moveRate);

            // Rotate with Interval Velocity by Overwriting Transform Rotation
            // Calculating the angle
            float angle = Mathf.Atan2(rgbd.velocity.y, rgbd.velocity.x) * Mathf.Rad2Deg;
            // Reversing and Modifying Rotating angle based on SPawn Directions
            if (startPos.x > 0) {
               angle = angle - 180 - 45;
            }
            else {
                angle += 45;
            }
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Reset Interval for next Iterations
            moveInterval = 0f;
        }
    }
}
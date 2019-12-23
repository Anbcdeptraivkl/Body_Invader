using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Move -> Turn -> Move Pattern (Horizontal by Default, Vertical will be implemented later)*/
public class EnemyTurningMovement : MonoBehaviour {
    [System.Serializable]
    public enum TurnDirection {
        Horizontal,
        Vertical
    }

    [SerializeField]
    float pivotRadius= 0f;
    // Initial Speeds
    [SerializeField]
    float startXSpeed = 0f;
    [SerializeField]
    float startYSpeed = 0f;
    [SerializeField]
    float targetDistance = 0f;
    [SerializeField]
    TurnDirection direction = TurnDirection.Horizontal;

    // References
    Rigidbody2D rgbd;

    // The last position that will be used for calculating, and will be updated every frame
    Vector3 lastPosition;
    float distanceTravelled = 0;
    // THe Pivot point for Rotation
    Vector2 turningPoint;
    // 1/100 turning interval
    float intervalAngle = 0f;

    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        // Starting values
        lastPosition = transform.position;
        // Dynamic pivot (depend on left spawned or right spawned)
        if (lastPosition.x <= 0)
            turningPoint = new Vector2(lastPosition.x + targetDistance, pivotRadius);
        else
            turningPoint = new Vector2(lastPosition.x - targetDistance, pivotRadius);
        // Init
        rgbd.velocity = new Vector2(startXSpeed, startYSpeed);
    }

    void FixedUpdate() {
        HorizontalTurnMove();
    }

    // Continous Dynamic Turning Movement
    void HorizontalTurnMove() {
        // Start Turning when reach DIstance
        if (distanceTravelled >= targetDistance) {
            // Stop Moving
            rgbd.velocity = Vector2.zero;
            // Rotate til the target 180 degree
            intervalAngle += 180 * Time.deltaTime;
            if (intervalAngle <= 180) {
                // Dynamic Left / Right Rotate rate: 180 deg / second
                if (lastPosition.x <= 0)
                    transform.RotateAround(turningPoint, Vector3.forward, 180 * Time.deltaTime);
                else 
                     transform.RotateAround(turningPoint, Vector3.forward, -180 * Time.deltaTime);
            }
            // After Full Angle Rotation, continue Moving in opposite directions and then terminate
            else if (intervalAngle > 180) {
                rgbd.velocity = new Vector2(-startXSpeed, startYSpeed);
                return;
            }
        } else {
            // Updating Distances if moving
            distanceTravelled += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;
        }
    }

    void VerticalTurnMove() {

    }
}
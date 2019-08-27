using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Movement of the Titan Enemy, from start to loop:
public class TitanMovement: MonoBehaviour {
    // Speed Values:
    public float ySpeed;
    public float sideSpeed;
    public float speedSmoothLimit;

    // Time values:
    public float startDelay;
    public float downTime;

    // Bounds:
    public Boundary bounds;

    // Updating boundings:
    private float currentDownSpeed;
    private float currentSideSpeed;
    private float leftSpeed;
    private float rightSpeed;


    private Rigidbody2D rgbd;

    void Start() {
        // Reference:
        rgbd = gameObject.GetComponent<Rigidbody2D>();

        // Starting Speed values:
        currentDownSpeed = 0;
        currentSideSpeed = 0;

        leftSpeed = -sideSpeed;
        rightSpeed = sideSpeed;

        StartCoroutine("Move");
    }

    void FixedUpdate() {
        SetMovement();
        // ClampToBound();
    }

    IEnumerator Move() {
        yield return new WaitForSeconds(startDelay);

        // Moving Down:
        currentDownSpeed = ySpeed;
        yield return new WaitForSeconds(downTime);
        // Stop moving down and start side-stepping:
        // SImple Movement first!:
        currentDownSpeed = 0;
        currentSideSpeed = (Random.value > 0.5) ? rightSpeed : leftSpeed;
    }

    void SetMovement() {
        // Changing Direction on Clamped:
        Debug.Log(currentSideSpeed);
        if (rgbd.position.x >= bounds.xMax) {
            currentSideSpeed = leftSpeed;
        } else {
            if (rgbd.position.x <= bounds.xMin) {
                currentSideSpeed = rightSpeed;
            }
        }

        Debug.Log(currentSideSpeed);

        // Setting the velocity;
        float sideManeuver = Mathf.MoveTowards(
            rgbd.velocity.x,
            currentSideSpeed,
            Time.deltaTime * speedSmoothLimit);

        rgbd.velocity = new Vector2(sideManeuver, currentDownSpeed);
    }

    void ClampToBound()
	{
        // Clamping:
		rgbd.position = new Vector2(
			Mathf.Clamp(rgbd.position.x, bounds.xMin, bounds.xMax),
			Mathf.Clamp(rgbd.position.y, bounds.yMin, bounds.yMax)
		);
	}

}
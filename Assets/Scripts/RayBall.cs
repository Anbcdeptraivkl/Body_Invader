using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotate and Shooting Ray continously
public class RayBall: MonoBehaviour {
    // CUrrently Inactive
    public GameObject deathRay;

    [SerializeField]
    float ySpeedMod = 0f;
    [SerializeField]
    float moveTime = 0f;
    [SerializeField]
    float rotateTime = 0f;
    [SerializeField]
    float targetRotatingAngle = 90f;

    Rigidbody2D rgbd;
    Animator rayAnimator;
    BoxCollider2D rayCollider;

    float delayTime = 1f;
    Vector2 colliderSize;

    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        rayAnimator = deathRay.GetComponent<Animator>();
        rayCollider = deathRay.GetComponent<BoxCollider2D>();
        colliderSize = rayCollider.size;
        StartCoroutine(ActionsSequenceExecute());
    }

    IEnumerator ActionsSequenceExecute() {
        // Move for a time then stop
        rgbd.velocity = new Vector2(rgbd.velocity.x, rgbd.velocity.y + ySpeedMod);
        yield return new WaitForSeconds(moveTime);
        //Stop moving and then Shoot Cycle Laser on LateUpdate()
        rgbd.velocity = Vector2.zero;
        // Time-based Rotations
        StartCoroutine(FirstSequence());
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(RepeatingSequence());
    }

    IEnumerator FirstSequence() {
        // First Rotation
        // Starting values
        float currentRotatingRate= 0;
        Quaternion startRotation = transform.rotation;
        // Looping and Lerping (with Time-based Rate and Frame Await)
        while (currentRotatingRate <= 1) {
            currentRotatingRate += Time.deltaTime / rotateTime;
            transform.rotation = Quaternion.Slerp(
                startRotation, 
                Quaternion.AngleAxis(targetRotatingAngle, Vector3.forward), 
                currentRotatingRate);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator RepeatingSequence() {
        // Shooting and Actacking continously

        while (true) {
            // Activate Ray
            ShootDeathRay();
            yield return new WaitForSeconds(delayTime);
            // Starting values
            float currentRotatingRate= 0;
            Quaternion startRotation = transform.rotation;
            // Looping and Lerping (with Frame Await)
            while (currentRotatingRate <= 1) {
                // Longer Rotate Time (double)
                currentRotatingRate += Time.deltaTime / (rotateTime * 1.5f);
                // Lerping Rotation to the opposite direction after the First rotation
                transform.rotation = Quaternion.Slerp(
                    startRotation, 
                    Quaternion.AngleAxis(-targetRotatingAngle, Vector3.forward), 
                    currentRotatingRate);
                yield return new WaitForEndOfFrame();
            }
            // Trigger Stop Animation and Deactivate Ray
            StopDeathRay();

            targetRotatingAngle = -targetRotatingAngle;
            yield return new WaitForSeconds(delayTime);
        }
    }

    void ShootDeathRay() {
        // Activate - Animations will automatically Play (Start State) and Loop (Ongoing State)
        if (!deathRay.activeSelf)
            deathRay.SetActive(true);
        // Replay Animation and Recollide
        rayAnimator.SetBool("Stopped", false);
        rayAnimator.Play("StartRay", 0, 0);
        rayCollider.size = colliderSize;
    }

    void StopDeathRay() {
        // Play StopRay Animation and Temp Disable Collider
        rayAnimator.SetBool("Stopped", true);
        rayCollider.size = new Vector2(0, 0);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Forward - Backward movement of the tri-UFO */
public class UFOMovement: MonoBehaviour {
    public float backRate = 5;

    public float ySpeed = -3;
    public float negYSpeed = 3;

    public float forwardTime = 2.0f;

    Rigidbody2D rgbd;

    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine("ForthAndBack");
    }

    void LateUpdate() {
        rgbd.velocity = new Vector2(0, ySpeed);
    }

    IEnumerator ForthAndBack() {
        yield return new WaitForSeconds(forwardTime);

        ySpeed = Mathf.Lerp(ySpeed, negYSpeed, Time.time * backRate);

        yield break;
    }
}
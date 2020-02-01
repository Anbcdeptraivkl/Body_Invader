using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*For Red Tracking Enemy: Move for a short time, then Track Attack (while continue Moving)*/
public class TrackerShortMovement : MonoBehaviour
{
    public float startDelay;
    public float moveSpeed;
    public Vector2 timeRange;

    Rigidbody2D rgbd;

    void Start() {
        rgbd = GetComponent<Rigidbody2D>();
        StartCoroutine("MoveShort");
    }

    //Move for a set amount of time then start tracking:
    IEnumerator MoveShort() {
        yield return new WaitForSeconds(startDelay);

        float moveTime = Random.Range(timeRange.x, timeRange.y);

        rgbd.velocity = new Vector2(0, moveSpeed);

        yield return new WaitForSeconds(moveTime);

        // Strat Tracking after sometime moving
        StartTracking();

        yield break;
    }

    void StartTracking() {
        gameObject.GetComponent<TrackerTracking>().enabled = true;
    }
    

}

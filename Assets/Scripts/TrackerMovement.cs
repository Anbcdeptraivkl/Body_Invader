using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*For Red Tracking Enemy: Move for a short time, then Track Attack (while continue Moving)*/
public class TrackerMovement : MonoBehaviour
{
    public float startDelay;
    public float moveSpeed;
    public float moveTime;

    Rigidbody2D rgbd;

    void Start() {
        rgbd = GetComponent<Rigidbody2D>();
        StartCoroutine("Move");
    }

    //Move for a set amount of time then start tracking:
    IEnumerator Move() {
        yield return new WaitForSeconds(startDelay);

        rgbd.velocity = new Vector2(0, moveSpeed);

        yield return new WaitForSeconds(moveTime);

        // Strat Tracking after sometime moving
        StartTracking();

        yield break;
    }

    void StartTracking() {
        gameObject.transform.Find("Toad").gameObject.GetComponent<TrackerTracking>().enabled = true;
    }
    

}

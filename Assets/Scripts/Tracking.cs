using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Moving, Shooting and Rotating the Enemy following the player's position using Logic, Values and References*/

public class Tracking : MonoBehaviour
{
    public float startDelay;
    public float moveSpeed;

    public float moveSmoothLimit;
    public Vector2 timeRange;

    public Transform playerTransform;


    Rigidbody2D rgbd;

    void Start() {
        rgbd = GetComponent<Rigidbody2D>();

        StartCoroutine("MoveShort");
    }

    //Move for a set amount of time then stop:
    IEnumerator MoveShort() {
        yield return new WaitForSeconds(startDelay);

        float moveTime = Random.Range(timeRange.x, timeRange.y);

        rgbd.velocity = new Vector2(0, moveSpeed);

        yield return new WaitForSeconds(moveTime);

        rgbd.velocity = new Vector2(0, 0);


        yield break;
    }

    

}

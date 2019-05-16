using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Moving a short time, then stop (and start acting)*/

public class ShortMovement : MonoBehaviour
{
    public float startDelay;
    public float moveSpeed;

    public Vector2 timeRange;

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

        //After finish moving, start rotating:
        StartTracking();

        yield break;
    }

    void StartTracking() {
        gameObject.GetComponent<EnemyTracking>().enabled = true;
    }
    

}

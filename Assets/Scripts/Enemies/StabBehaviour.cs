using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Homing at Player's old Position(s) */
public class StabBehaviour : MonoBehaviour
{
    public float slideSpeedY = 0;
    public float slideTime = 0;
    public float homeSpeed = 0;
    public float rotateRate = 0;

    Rigidbody2D rigidbody2;
    Transform playerTrans;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = gameObject.GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");
        // When found player, home toward it
        if (player) {
            playerTrans = player.GetComponent<Transform>();
            StartCoroutine(Move());
        }
    }

    IEnumerator Move() {
        // FLoat down vertically, then stop
        rigidbody2.velocity = new Vector2(0, slideSpeedY);
        yield return new WaitForSeconds(slideTime);
        rigidbody2.velocity = Vector2.zero;

        // Rotate to Current recorded Player position
        Vector3 playerPos = playerTrans.position;
        Vector3 direction = (playerPos - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.forward);
        // Only Rotate Forward
        targetRotation.x = 0;
        targetRotation.y = 0;

        do {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateRate * Time.deltaTime);
            yield return null;
        } while (
            // Checking for the current direction
            Vector3.Angle(transform.up, direction) > 1 &&
            Vector3.Angle(transform.up, direction) < 179);
        // Home toward Player
        Vector2 homeVelocity = new Vector2(direction.x * homeSpeed, direction.y * homeSpeed);
        rigidbody2.velocity = homeVelocity;
    }
}

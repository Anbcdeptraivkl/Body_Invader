using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Tricky movements for enemy ships: 
MOve > Dogde > COntinue > Rinse and Repeat.
*/
public class EnemyMovement : MonoBehaviour
{
    public float currentVerticalSpeed;
    public float maneuverSpeed;
    public float maneuverSmoothLimit;

    //Range for random yielding:
    public float startDelay;
    public float maneuverTime;
    public float timeTilNextMove;
    
    private float maneuverTargetSpeed;

    //Private References:
    private Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody and initiative speed:
        rg = GetComponent<Rigidbody2D>();
        VerticalMovement();
        //Start Evasion Coroutine:
        StartCoroutine(EvasiveManeuver());
    }

    void VerticalMovement()
    {
        rg.velocity = new Vector2(0.0f, currentVerticalSpeed);
    }

    IEnumerator EvasiveManeuver()
    {
        //Every values got determined randomly.
        //Starting delay time:
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            //Determine horizontal dogding speed (inverse toward the center), then start applying:
            maneuverTargetSpeed = maneuverSpeed * -Mathf.Sign(rg.position.x);
            yield return new WaitForSeconds(maneuverTime);
            //Reset to vertical move and wait for a new loop:
            maneuverTargetSpeed = 0;
            yield return new WaitForSeconds(timeTilNextMove);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        SetManeuverSpeed();
        //Rotation tilt follow maneuvering directions:
    }

    void SetManeuverSpeed() {
        //Slowly increase x maneuvering speed:
        float maneuver = Mathf.MoveTowards(
            rg.velocity.x, 
            maneuverTargetSpeed, 
            Time.deltaTime * maneuverSmoothLimit);

        //Apply to movement:
        rg.velocity = new Vector2(maneuver, currentVerticalSpeed);
    }

    void Tilt() {
        //
    }
}

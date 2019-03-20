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
    public float maxManeuverSpeed;
    public float maneuverSmoothLimit;
    public float tiltRate;

    //Range for random yielding:
    public Vector2 startDelayRange;
    public Vector2 maneuverTimeRange;
    public Vector2 TimeTilNextManeuveringRange;
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
        //Starting delay time:
        yield return new WaitForSeconds(Random.Range(startDelayRange.x, startDelayRange.y));

        while (true)
        {
            //Determine horizontal dogding speed (inverse toward the center), then start applying:
            maneuverTargetSpeed = Random.Range(1, maxManeuverSpeed) * -Mathf.Sign(rg.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTimeRange.x, maneuverTimeRange.y));
            //Reset to vertical move and wait for a new loop:
            maneuverTargetSpeed = 0;
            yield return new WaitForSeconds(Random.Range(
                TimeTilNextManeuveringRange.x,
                TimeTilNextManeuveringRange.y));
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Slowly increase x maneuvering speed:
        float maneuverSpeed = Mathf.MoveTowards(
            rg.velocity.x, 
            maneuverTargetSpeed, 
            Time.deltaTime *maneuverSmoothLimit);
        //Apply to movement:
        rg.velocity = new Vector2(maneuverSpeed, currentVerticalSpeed);
        //Rotation tilt follow maneuvering directions:
        rg.rotation = -(rg.velocity.x * tiltRate);
    }
}

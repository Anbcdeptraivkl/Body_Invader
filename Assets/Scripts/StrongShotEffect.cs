using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongShotEffect : MonoBehaviour
{

    public GameObject strongShockParticle;

    public GameObject HitShock() {
        return Instantiate(
            strongShockParticle,
            transform.position,
            Quaternion.identity
        ) as GameObject;
    }
}

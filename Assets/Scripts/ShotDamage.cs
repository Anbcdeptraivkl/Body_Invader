using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Damage component shared between shot objects:
public class ShotDamage: MonoBehaviour {

    [SerializeField]
    float damage = 1;

    public float GetDamage() {
        return damage;
    }
}
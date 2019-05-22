using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Damage component shared between shot objects:
public class ShotDamage: MonoBehaviour {

    [SerializeField]
    int damage = 1;

    public int GetDamage() {
        return damage;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfClean : MonoBehaviour {
    void Update() {
        if (transform.childCount == 0)
            Destroy(gameObject, 2f);
    }
}
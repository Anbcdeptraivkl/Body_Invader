using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate: MonoBehaviour
{
    public float rotationRate;

    public float rotationPerMin;

    void Start() {

    }

    void Update() {
        transform.Rotate(0, 0, rotationRate*rotationPerMin*Time.deltaTime);
    }
}
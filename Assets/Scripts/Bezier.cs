using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cubic Bezier using Points Formation:
// Extremely useful for smooth curvy movements and transforming in general:
public class Bezier : MonoBehaviour
{
    public LineRenderer line;

    public bool movable;

    public float moveTime = 2.0f;

    public int numOfSteps = 100;

    [SerializeField]
    private Transform p0, p1, p2;

    private Vector3[] pointPositions = new Vector3[40];

    float timeStep;


    void Start() {
        timeStep = moveTime / numOfSteps;

        if (line) {
            line.positionCount = numOfSteps;

            DrawQuadCurve();
        }

        if (movable) {
            StartCoroutine("MoveCurve");
        }

    }

    public void SetPoints(Transform p0t, Transform p1t, Transform p2t) {
        p0 = p0t;
        p1 = p1t;
        p2 = p2t;
    }

    void DrawQuadCurve() {
        for (int i = 1; i < numOfSteps + 1; i++) {
            float t = i / (float)numOfSteps;

            pointPositions[i - 1] = CalculateQuadBezierPoint(t, p0.position, p1.position, p2.position);
        }

        line.SetPositions(pointPositions);
    }

    IEnumerator MoveCurve() {
        //Moving in Curve using Bezier Algorithms and Fixed Time-Step Incremental Interpolation:
        for (int i = 1; i < numOfSteps + 1; i++) {
            float t = i / (float)numOfSteps;

            transform.position = CalculateQuadBezierPoint(t, p0.position, p1.position, p2.position);

            yield return new WaitForSeconds(timeStep);
        }
    }

    private Vector3 CalculateQuadBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2) {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 b = uu*p0 + 2*u*t*p1 + tt*p2;

        return b;
    }

    
}

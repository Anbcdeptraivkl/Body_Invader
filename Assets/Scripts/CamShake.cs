using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{

    Vector3 originalPos;

    void Start() {
        originalPos = transform.position;
    }

   public void StartShaking(float shakeMagnitude = 0.5f, float shakeDuration = 0.1f) {
       StartCoroutine(Shake(shakeMagnitude, shakeDuration));
   }

   IEnumerator Shake(float magnitude, float duration) {

        // USing elasped time to implement fixed time step update:
        float elaspedTime = 0.0f;

        while (elaspedTime <= duration) {
            
            float newX = Random.Range(-1, 1) * magnitude;
            float newY = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(newX, newY, originalPos.z);

            elaspedTime += Time.deltaTime;

            // Return and run every new Update Loops (per update running!)
            yield return null;
        }

        // After done shaking, return the position to origin:
        transform.localPosition = originalPos;

   }


}

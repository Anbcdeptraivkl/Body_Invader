using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public float shakeMagnitude = 0.4f, duration = 0.25f;

   public void StartShaking() {
       StartCoroutine("Shake");
   }

   IEnumerator Shake() {

        Vector3 originalPos = transform.position;

        // USing elasped time to implement fixed time step update:
        float elaspedTime = 0.0f;

        while (elaspedTime <= duration) {
            
            float newX = Random.Range(-1, 1) * shakeMagnitude;
            float newY = Random.Range(-1, 1) * shakeMagnitude;

            transform.localPosition = new Vector3(newX, newY, originalPos.z);

            elaspedTime += Time.deltaTime;

            // Return and run every new Update Loops (per update running!)
            yield return null;
        }

        // After done shaking, return the position to origin:
        transform.localPosition = originalPos;

   }


}

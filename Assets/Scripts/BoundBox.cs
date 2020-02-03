using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroy Off-screen Objects and their children (by COllision Detections)
public class BoundBox : MonoBehaviour {
	void OnTriggerExit2D (Collider2D other)
	{
		//Exclude Backgrounds:
		if (other.gameObject.tag != "Background" ||
			other.gameObject.tag != "DeathRay") {
			// Destroy all the children and the game objects itself will then be removed:
			foreach (Transform childObj in other.gameObject.transform) {
				Destroy(childObj.gameObject, 0.5f);
				// Debug.Log(childObj.name + " destroyed");
			}

			Destroy(other.gameObject, 0.5f);
		}
	}
}

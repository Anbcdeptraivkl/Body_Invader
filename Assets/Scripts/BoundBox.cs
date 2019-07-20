using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundBox : MonoBehaviour {
	void OnTriggerExit2D (Collider2D other)
	{
		//Exclude Backgrounds:
		if (other.gameObject.tag != "Background") {
			// Destroy all the children and the game objects itself will then be removed:
			foreach (Transform childObj in other.gameObject.transform) {
				Destroy(childObj.gameObject, 0.5f);
			}

			// Destroy the parents for some types of objects where the parents don't move with their children:
			if (other.transform.parent != null) {
				Destroy(other.transform.parent.gameObject, 1.0f);
			}
			
			Destroy(other.gameObject, 0.5f);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundBox : MonoBehaviour {
	void OnTriggerExit2D (Collider2D other)
	{
		//Exclude Backgrounds:
		if (other.gameObject.tag != "Background")
			Destroy(other.gameObject);
	}
}

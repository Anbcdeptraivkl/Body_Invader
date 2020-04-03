using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour {
	// The Count of all the enemies inside the scene
	static int count = 0;

	void Awake() {
		count++;
	}

	void OnDestroy() {
		count--;
	}

	static public bool Wiped() {
		return (count <= 0);
	}

	public int GetCount() {
        return count;
    }
}
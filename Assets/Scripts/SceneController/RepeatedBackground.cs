using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatedBackground: MonoBehaviour {
	public float scrollSpeed = 10f;
	Vector2 startingPosition;
	bool scrollable = true;
	Renderer render;
	Rigidbody2D rgbd;

	void Start() {
		startingPosition = transform.position;
		render = GetComponent<Renderer>();
		rgbd = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		if (scrollable) {
			rgbd.velocity = new Vector2(0, -(scrollSpeed * Time.deltaTime));
		}
	}

	private void OnBecameInvisible() {
		// Reset Position on Finished Scrolling
		transform.position = startingPosition;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatedBackground: MonoBehaviour {
	public float scrollSpeed = -1f;
	Renderer render;

	void Start() {
		render = GetComponent<Renderer>();
	}

	void Update() {
		// Continous Offseting and Repeating
		render.material.mainTextureOffset = new Vector2(0, scrollSpeed * Time.time);
	}
}
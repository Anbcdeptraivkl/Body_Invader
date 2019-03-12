using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speed;
	Rigidbody2D rgbd;
	// Use this for initialization
	void Start () {
		rgbd = gameObject.GetComponent<Rigidbody2D>();
		setMovement();
	}

	void setMovement ()
	{
		rgbd.velocity = Vector2.up * speed;
	}
	
}

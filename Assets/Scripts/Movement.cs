using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float xSpeed;
	public float ySpeed;
	Rigidbody2D rgbd;
	// Use this for initialization
	void Start () {
		rgbd = gameObject.GetComponent<Rigidbody2D>();
		setMovement();
	}

	void setMovement ()
	{
		rgbd.velocity = new Vector2(xSpeed, ySpeed);
	}
	
}

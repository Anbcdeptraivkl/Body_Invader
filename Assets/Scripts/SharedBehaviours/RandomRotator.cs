using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	// Use this for initialization
	public float tumbleSpeed;
	Rigidbody2D rgbd2D;
	void Start () {
		rgbd2D = GetComponent<Rigidbody2D>();
		Tumble();
	}
	
	void Tumble()
	{
		rgbd2D.angularVelocity = pickRotator(Random.value, 10.0f) * tumbleSpeed;
	}

	float pickRotator(float randomNum, float speed)
	{
		float returnValue = 0.0f;
		if (randomNum <= 0.5f)
		{
			returnValue = -speed;
		}
		else
		{
			returnValue = speed;
		}
		return returnValue;
	}
}

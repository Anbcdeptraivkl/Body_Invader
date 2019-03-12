using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {

	static int score;
	void Start() {
		InitScore();
	}
	void InitScore()
	{
		score = 0;
	}
	void AddScore()
	{
		score++;
	}
	int GetScore()
	{
		return score;
	}
}

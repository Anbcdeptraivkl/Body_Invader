using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject hazardObject;
	public int hazardsPerWave;
	public Vector3 spawnReference;
	public float startTimer;
	public float spawnTimer;
	public float waveBreak;
	bool isSpawning;
	// Use this for initialization
	void Start () {
		SetSpawnStatus(true);
		StartCoroutine(SpawnWaves());
	}
	//Co-routine to spawn endless waves:
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(startTimer);
		//Keep spawning from start to finish:
		while (isSpawning)
		{
			for (int i = hazardsPerWave; i > 0; --i)
			{
				SpawnSingle();
				//Between Hazards:
				yield return new WaitForSeconds(spawnTimer);
			}
			//Between waves:
			yield return new WaitForSeconds(waveBreak);
		}
	}
	void SpawnSingle() {
		Vector3 spawnPosition = new Vector3 (
					Random.Range(-spawnReference.x, spawnReference.x),
					spawnReference.y,
					spawnReference.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazardObject, spawnPosition, spawnRotation);
	}
	void SetSpawnStatus(bool spawning) {
		isSpawning = spawning;
	}
}

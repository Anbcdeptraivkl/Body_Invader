using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldSpawnManager : MonoBehaviour
{
    public GameObject normalEnemy;

	public int hazardsPerWave;
	public Vector3 spawnPositionReference;
	public float startDelay;
	public float spawnTime;
	public float waveDelay;

    GameOver gameOverRef;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameOverRef = controllerObject.GetComponent<GameOver>();

		StartCoroutine("SpawnWaves");
    }

    IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(startDelay);
		
		while (!gameOverRef.CheckGameOver())
		{
			for (int i = hazardsPerWave; i > 0; --i)
			{
				SpawnSingle();
				//Between Hazards:
				yield return new WaitForSeconds(spawnTime);
			}
			//Between waves:
			yield return new WaitForSeconds(waveDelay);
		}
	}
	void SpawnSingle() {
		Vector3 spawnPosition = new Vector3 (
					Random.Range(-spawnPositionReference.x, spawnPositionReference.x),
					spawnPositionReference.y,
					spawnPositionReference.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (
			normalEnemy, 
			spawnPosition, 
			spawnRotation);
	}
}

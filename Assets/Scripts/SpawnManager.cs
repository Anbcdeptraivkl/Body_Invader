using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] hazardObjectsList;
	public int hazardsPerWave;
	public Vector3 spawnReference;
	public float startTimer;
	public float spawnTimer;
	public float waveBreak;

    GameOver gameOverRef;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameOverRef = controllerObject.GetComponent<GameOver>();

		StartCoroutine("SpawnWaves");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(startTimer);
		//Keep spawning from start to finish:
		while (!gameOverRef.CheckGameOver())
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
		Instantiate (
			hazardObjectsList[Random.Range(0, hazardObjectsList.Length)], 
			spawnPosition, 
			spawnRotation);
	}
}

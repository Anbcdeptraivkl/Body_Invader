using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPManager : MonoBehaviour
{
    public int baseHP;
    public int scoreValue;

    public GameObject shotExplosion;
    public AudioSource explodingSound;

    bool gotMissiled;

    float currentHP;
    
    ScoreManager scoreManager;
    EnemyItemDropper dropper;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = Mathf.Abs(baseHP);

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			
			scoreManager = gameControllerObject.GetComponent<ScoreManager>();
		}
			else
			{
				Debug.Log("Failed to load <GameController> script component.");
			}

        dropper = gameObject.GetComponent<EnemyItemDropper>();

        gotMissiled = false;
    }

    // Deal a set Amount of Dmgs to Enemies, explode enemies if HP went below 0:
    public bool DecreaseHP(float value = 1) {
        currentHP -= value;

        if (value >= 3)
            gotMissiled = true;

        bool alive = Alive();

        gotMissiled = false;

        return alive; 
    }

    public void IncreaseHP(float value = 1) {
        currentHP += value;
    }

    public float GetCurrentHP() {
        return currentHP;
    }

    bool Alive () {
        if (currentHP > 0) {
            return true;
        }
        else
        {
            Dying();
            return false;
        }
    }

    // Die and Explode:
    void Dying() {
        shotExplosion = Instantiate(
            shotExplosion, 
            transform.position, 
            transform.rotation) as GameObject;

        if (!gotMissiled) {
            explodingSound.Play();
        }
        
        Destroy(shotExplosion, 1.0f);

        // Item Drop:
        dropper.CalculateRandomDrop();
        // Loot Drop:
        dropper.DropPersistences();

        scoreManager.UpdateScore(scoreValue);	

        Destroy(gameObject);

    }
}

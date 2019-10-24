using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy HP and Dying Controller
public class EnemyHPManager : MonoBehaviour
{
    public int baseHP;
    public int scoreValue;
    public int energyReward = 5;

    public GameObject shotExplosion;
    public AudioSource explodingSound;

    bool gotMissiled;

    float currentHP;
    
    // Script References
    ScoreManager scoreManager;
    EnemyItemDropper dropper;
    PlayerEnergy eneryManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = Mathf.Abs(baseHP);

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject player = GameObject.FindWithTag("Player");

		if (gameControllerObject != null) 
		{
			
			scoreManager = gameControllerObject.GetComponent<ScoreManager>();
		}
			else
			{
				Debug.Log("Failed to load <GameController> script component.");
			}

        if (player != null) 
		{
			
			eneryManager = player.GetComponent<PlayerEnergy>();
		}
			else
			{
				Debug.Log("Failed to load <Player> Reference");
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

        // Refill Energy
        if (eneryManager)
            eneryManager.RefillEnergy(energyReward);

        // Item Drop:
        dropper.CalculateRandomDrop();
        // Loot Drop:
        dropper.DropPersistences();

        // Increase Score
        scoreManager.UpdateScore(scoreValue);	

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy HP and Dying Controller
public class EnemyHPManager : MonoBehaviour
{
    public int baseHP;
    public int energyReward = 5;

    public GameObject shotExplosion;
    public AudioSource explodingSound;

    bool gotMissiled;

    float currentHP;
    
    // Script References
    EnemyItemDropper dropper;
    PlayerEnergy eneryManager;
    CamShake camShaker;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = Mathf.Abs(baseHP);

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null) 
		{
			
			eneryManager = player.GetComponent<PlayerEnergy>();
		}
			else
			{
				Debug.Log("Failed to load <Player> Reference");
			}

        // Getting camera components:
        GameObject mainCam = GameObject.FindWithTag("MainCamera");

        if (mainCam != null) {
            camShaker = mainCam.GetComponent<CamShake>();
        } else {
            Debug.Log("No camera found.");
        }

        dropper = gameObject.GetComponent<EnemyItemDropper>();

        gotMissiled = false;
    }

    // Deal a set Amount of Dmgs to Enemies, explode enemies if HP went below 0:
    public bool DecreaseHP(float value = 1) {
        currentHP -= value;

        if (value >= 10) //Rocket Dmg
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
        // Shake Cam
        camShaker.StartShaking(0.2f, 0.1f);

        // Refill Energy
        if (eneryManager)
            eneryManager.RefillEnergy(energyReward);
        // Item Drop:
        dropper.CalculateRandomDrop();
        // Loot Drop:
        dropper.DropPersistences();
        // Spawn and Control Explosions
        shotExplosion = Instantiate(
            shotExplosion, 
            transform.position, 
            transform.rotation) as GameObject;
        Destroy(shotExplosion, 0.5f);

        if (!gotMissiled) {
            explodingSound.Play();
        }

        Destroy(gameObject);
    }
}

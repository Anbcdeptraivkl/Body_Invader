using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
** ON GETTING HIT BY SHOTS **
- Decrease HP, 
- Play on-hit animations: Blinking animations, Hit-schock Particles, Shaking effects.
- Destroy if out of hp and:
    + Increase Score.
*/
public class EnemyGettingShot : MonoBehaviour
{
    public int scoreValue;

    public bool isOnhit;

    Animator objAnimator;

    public GameObject hitShockParticle;
    public GameObject shotExplosion;

    ScoreManager scoreManager;
    EnemyHPManager hpManager;
    EnemyItemDropper dropper;

    CamShake camShaker;

    
    void Start() {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			
			scoreManager = gameControllerObject.GetComponent<ScoreManager>();
		}
			else
			{
				Debug.Log("Failed to load <GameController> script component.");
			}
        
        hpManager = gameObject.GetComponent<EnemyHPManager>();

        dropper = gameObject.GetComponent<EnemyItemDropper>();

        objAnimator = gameObject.GetComponent<Animator>();

        // Getting camera components:
        GameObject mainCam = GameObject.FindWithTag("MainCamera");

        if (mainCam != null) {
            camShaker = mainCam.GetComponent<CamShake>();
        } else {
            Debug.Log("No camera found.");
        }

    }

    void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.tag != "Boundary" ) {

			if (other.gameObject.tag == "Shot") {

                // Check the Shot Damage,then Decrease Hp and Destroy the SHot:
                float shotDmg = other.gameObject.GetComponent<ShotDamage>().GetDamage();
               
                hpManager.DecreaseHP(shotDmg);

                // On hit Animations and Effects:
                PlayOnHitEffects(other);

                // Destroy the shot objects after colliding:
                Destroy(other.gameObject);
            }
		}
	}

    void PlayOnHitEffects(Collider2D other) {
        if (hpManager.Alive() && isOnhit) {
            // Cam Shake:
            camShaker.StartShaking();
            // BLinking animations:
            objAnimator.SetTrigger("Hit");
            // CHecking for the Colliding shot types, and instantiate the effects as followed:
            GameObject hitParticle;
            hitParticle = Instantiate(
                hitShockParticle,
                other.gameObject.transform.position,
                other.gameObject.transform.rotation
            ) as GameObject;
            
            Destroy(hitParticle, 1.0f);
        } else {
            if (!hpManager.Alive()) {
                Dying();
            }
        }
    }

    void Dying() {

        shotExplosion = Instantiate(
            shotExplosion, 
            transform.position, 
            transform.rotation) as GameObject;
        
        Destroy(shotExplosion, 1.0f);

        // Item Drop:
        dropper.CalculateRandomDrop();
        // Loot Drop:
        dropper.DropPersistences();

        scoreManager.UpdateScore(scoreValue);	

        Destroy(gameObject);

    }
}

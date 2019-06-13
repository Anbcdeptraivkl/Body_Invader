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
    EnemyUpgDropper upgDropper;

    
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

        upgDropper = gameObject.GetComponent<EnemyUpgDropper>();

        objAnimator = gameObject.GetComponent<Animator>();

    }

    void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.tag != "Boundary" ) {

			if (other.gameObject.tag == "Shot") {

                // Check the Shot Damage,then Decrease Hp and Destroy the SHot:
                float shotDmg = other.gameObject.GetComponent<ShotDamage>().GetDamage();
               
                hpManager.DecreaseHP(shotDmg);

                // If not dead yet:
                // Play On-hit Animation + Particle Effects (then reset for cycling animations)
                if (hpManager.Alive() && isOnhit) {

                    // BLinking animations:
                    objAnimator.SetTrigger("Hit");

                    // CHecking for the Colliding shot types, and instantiate the effects as followed:
                    StrongShotEffect strongShootEffect = other.GetComponent<StrongShotEffect>();
                    GameObject hitParticle;

                    if (strongShootEffect) {
                        // Strong Impact:
                        hitParticle = strongShootEffect.HitShock();
                    } else {
                        // Normal Impact Particles instantiating and destruction:
                        hitParticle = Instantiate(
                            hitShockParticle,
                            other.gameObject.transform.position,
                            other.gameObject.transform.rotation
                        ) as GameObject;
                    }

                    Destroy(hitParticle, 1.0f);

                } else {
                    if (!hpManager.Alive()) {
                        Dying();
                    }
                }

                // Destroy the shot objects after colliding:
                Destroy(other.gameObject);
            }
		}
	}

    void Dying() {

        shotExplosion = Instantiate(
            shotExplosion, 
            transform.position, 
            transform.rotation) as GameObject;
        
        Destroy(shotExplosion, 1.0f);

        upgDropper.CalculateDrop();

        scoreManager.UpdateScore(scoreValue);	

        Destroy(gameObject);

    }
}

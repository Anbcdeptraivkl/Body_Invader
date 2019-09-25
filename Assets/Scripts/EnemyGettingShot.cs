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
    Animator objAnimator;

    public GameObject hitShockParticle;
    
    CamShake camShaker;
    
    EnemyHPManager hpManager;

    bool stillLiving;

    
    void Start() {

        

        objAnimator = gameObject.GetComponent<Animator>();
        hpManager = gameObject.GetComponent<EnemyHPManager>();

        // Getting camera components:
        GameObject mainCam = GameObject.FindWithTag("MainCamera");

        if (mainCam != null) {
            camShaker = mainCam.GetComponent<CamShake>();
        } else {
            Debug.Log("No camera found.");
        }

        stillLiving = true;
    }

    void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.tag != "Boundary" ) {

			if (other.gameObject.tag == "Shot") {

                // Check the Shot Damage,then Decrease Hp and Destroy the SHot:
                float shotDmg = other.gameObject.GetComponent<ShotDamage>().GetDamage();
               
                stillLiving = hpManager.DecreaseHP(shotDmg);

                // On hit Animations and Effects:
                PlayOnHitEffects(other);

                // Destroy the shot objects after colliding:
                Destroy(other.gameObject);
            }
		}
	}

    void PlayOnHitEffects(Collider2D other) {
        // If still alive: Hit Shock:
        if (stillLiving) {
            // Cam Shake:
            camShaker.StartShaking(0.15f, 0.05f);

            // BLinking animations:
            if (objAnimator)
                objAnimator.SetTrigger("Hit");
            else
                Debug.Log("No animator found");
                
            // CHecking for the Colliding shot types, and instantiate the effects as followed:
            GameObject hitParticle;
            hitParticle = Instantiate(
                hitShockParticle,
                other.gameObject.transform.position,
                other.gameObject.transform.rotation
            ) as GameObject;
            
            Destroy(hitParticle, 1.0f);
        }
    }

}

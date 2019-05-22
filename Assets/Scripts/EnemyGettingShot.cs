using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
** ON GETTING HIT BY SHOTS **
- Decrease HP, 
- Play on-hit animations.
- Destroy if out of hp and:
    + Increase Score.
*/
public class EnemyGettingShot : MonoBehaviour
{
    public int scoreValue;

    public bool isOnhit;
    public Animator onHitAnimation;
    public GameObject shotExplosion;

    ScoreManager scoreManager;
    EnemyHPManager hpManager;
    EnemyUpgDropper upgDropper;
    
    void Start()
    {
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
    }

    void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.tag != "Boundary" ) {

			if (other.gameObject.tag == "Shot") {

                if (isOnhit) {
                    onHitAnimation.Play("OnHit", -1, 0f);
                }

                //Decrease Hp and Destroy the SHot:
                hpManager.DecreaseHP();
                Destroy(other.gameObject);

                //Dieing:
                if (!hpManager.Alive()) {
                    
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
		}
	}
}

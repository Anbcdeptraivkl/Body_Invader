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
public class GettingShot : MonoBehaviour
{
    public int scoreValue;
    public Animator onHitAnimation;
    public GameObject shotExplosion;
    ScoreManager scoreManager;
    HPManager hpManager;
    
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
        
        hpManager = gameObject.GetComponent<HPManager>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.gameObject.tag != "Boundary" )
		{
			if (other.gameObject.tag == "Shot") {
                onHitAnimation.Play("OnHit", -1, 0f);
                hpManager.DecreaseHP();
                 Destroy(other.gameObject);
                //Destroy of dieing:
                if (!hpManager.Alive()) {
                    shotExplosion = Instantiate(
                        shotExplosion, 
                        transform.position, 
                        transform.rotation) as GameObject;
                   
                    Destroy(shotExplosion, 1.0f);

                    scoreManager.UpdateScore(scoreValue);		            
		            Destroy(gameObject);
                }
            }
		}
	}
}

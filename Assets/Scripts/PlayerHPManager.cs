using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Control the HP data + Visual and audio effects responds on HP: (including invin frames and low-hp warnings)
public class PlayerHPManager : MonoBehaviour
{
    [SerializeField]
    private int baseHp = 3;

    [SerializeField]
     UiHpController hpUi;

    public GameObject playerExplosion;

    public float invinTime;
	
    private GameOver gameOverController;

    protected int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = baseHp;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			gameOverController = gameControllerObject.GetComponent<GameOver>();
		}
			else
			{
				Debug.Log("Failed to load <GameController> script component.");
			}
    }

    public void DecreaseHp(int amount = 1) {

        currentHp -= amount;

        // Check for Remaining HP, and respond accordingly every Depletion:
        DepletingEffect();
        
        // Undamagable time:
        BeInvincible(invinTime);
    }

    public void IncreaseHp(int amount = 1) {

        if (currentHp < baseHp) {

            currentHp += amount;

        }
    }

    public int CurrentHp() {
        return currentHp;
    }

    public bool CheckAlive() {
        return currentHp > 0 ? true : false;
    }

    void DepletingEffect() {
       
       switch (currentHp) {

           case 3: {
               Debug.Log("No depleting happened");
           }
           break;

           case 2: {
               hpUi.Lose1();
           }
           break;

           case 1: {
               hpUi.Lose2();
           }
           break;

           case 0: {
               PlayerExplode();
           }
           break;
       }
    }

    // PLayer destroyed when hp depleted:
    void PlayerExplode() {
        //Check Death, then Explosions and Game Over:
          
        // Instantiate the explosion and play it for 2 secs:
        playerExplosion = Instantiate(
            playerExplosion, 
            transform.position,
            transform.rotation) as GameObject;
        
        Destroy(playerExplosion, 2.0f);

        //Game over since the player has been destroyed:
        gameOverController.Over();

        //Destroy the Player and end the game:
        Destroy(gameObject);
            
    }

    void BeInvincible(float time) {
        GetComponent<CapsuleCollider2D>().enabled = false;

        Invoke("StopInvincible", time);
    }

    void StopInvincible() {
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}

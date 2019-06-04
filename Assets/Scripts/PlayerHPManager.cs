using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Control the HP data + Visual and audio effects responds on HP: (including invin frames and low-hp warnings)
public class PlayerHPManager : MonoBehaviour
{
    [SerializeField]
    private int baseHp = 3;

    UiHpController hpUi;

    public GameObject playerExplosion;

    public AudioSource hitSound;

    public float invinTime = 0.75f;

	
    private GameOver gameOverController;

    private Collider2D playerCollider;

    private CamShake camShaker;

    private Animator playerAnimator;

    


    protected int currentHp;

    //Invincible checker: will affect enemy's shots and contacts behaviours:
    protected bool isInvin;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = baseHp;

        // Getting Game COntroller reference and components:
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		if (gameControllerObject != null) 
		{
			gameOverController = gameControllerObject.GetComponent<GameOver>();
		}
			else
			{
				Debug.Log("Failed to load <GameController> script component.");
			}

        // Getting camera components:
        GameObject mainCam = GameObject.FindWithTag("MainCamera");

        if (mainCam != null) {
            camShaker = mainCam.GetComponent<CamShake>();
        } else {
            Debug.Log("No camera found.");
        }

        GameObject status = GameObject.FindWithTag("PlayerStatus");

        if (status) {
            hpUi = status.GetComponent<UiHpController>();
        } else {
            Debug.Log("No Player UI found");
        }

        // Host components:
        playerCollider = GetComponent<CapsuleCollider2D>();

        playerAnimator = GetComponent<Animator>();

        //initiate Values:
        isInvin = false;
    }

    void Update() {

        // //Updating Invincibility frames:
        // if (isInvin) {
        //     Invincible();

        //     Invoke("StopInvin", invinTime);
        // }
    }

    // Deplete HP, then Update UI, then Play effects and start invincible frames for player:
    public void DecreaseHp(int amount = 1) {

        currentHp -= amount;

        // Check for Remaining HP, and respond accordingly every Depletion to UI:
        UIDepletingEffect();

        // To visual and sound effects:
        PlayImmersiveEffects();

        // INvincible frames:
        StartCoroutine("Invincible");

    }

    public void IncreaseHp(int amount = 1) {

        if (currentHp < baseHp) {

            currentHp += amount;

        }
    }

    public int CurrentHp() {
        return currentHp;
    }

    public bool CheckInvin() {
        return isInvin;
    }

    public bool CheckAlive() {
        return currentHp > 0 ? true : false;
    }

    void UIDepletingEffect() {
       
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

    void PlayImmersiveEffects() {

        camShaker.StartShaking();
        
        playerAnimator.SetTrigger("Hit");

        hitSound.Play();

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

    IEnumerator Invincible() {
        
        isInvin = true;

        yield return new WaitForSeconds(invinTime);

        isInvin = false;
    }

}

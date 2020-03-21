using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






//Control the HP data + Visual and audio effects responds on HP: (including invin frames and low-hp warnings)
public class PlayerHPManager : MonoBehaviour
{
    // HP Ui Struct:
    [System.Serializable]
    public struct HpUi {

        // The Images are disabled by Default and will be enabled when initiated by the main Functions:
        [SerializeField]
        public Image[] HeartsCollection;

        public Sprite fullHPSprite;
        public Sprite lostHPSprite;

    }

    // The UI Struct in action:
    public HpUi PlayerHpUi;

    [SerializeField]
    private int maxHp = 3;

    [SerializeField]
    protected int currentHp;

    public float invinTime = 0.75f;


    // External references:
    public GameObject playerExplosion;
    public AudioSource hitSound;
    public AudioSource hpUpSound;

    // References:
    private GameOver gameOverController;
    private Collider2D playerCollider;
    private CamShake camShaker;
    private Animator playerAnimator;

    //Invincible checker: will affect on enemy's shots and contacts behaviours:
    protected bool isInvin;

    // Hp Upgraded or not (not by default)
    bool hpUpgraded = false;


    // Start is called before the first frame update
    void Start()
    {
        // Initiate the Max Hp and Current Hp:
        maxHp = (hpUpgraded) ? 4 : 3;
        currentHp = maxHp;

        // Display Hearts:
        DrawHearts();
        

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

        // Host components:
        playerCollider = GetComponent<CapsuleCollider2D>();

        playerAnimator = GetComponent<Animator>();

        //Invin initiate Values:
        isInvin = false;
    }

    void DrawHearts() {
        // Draw the Hp Sprites:
        for (int i = 0; i < PlayerHpUi.HeartsCollection.Length; i++) {
            if (i < currentHp) {
                PlayerHpUi.HeartsCollection[i].gameObject.SetActive(true);
            } else {
                PlayerHpUi.HeartsCollection[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetHpUpgrade(bool value) {
        hpUpgraded = value;
    }

    // Deplete HP, then Update UI, then Play effects and start invincible frames for player:
    public void DecreaseHp(int amount = 1) {

        currentHp -= amount;

        if (currentHp <= 0) {
            PlayerExplode();
        }

        OnLosingHpUi();

        // To visual and sound effects:
        PlayImmersiveEffects();

        // INvincible frames:
        StartCoroutine("Invincible");

    }

    
    void OnLosingHpUi() {
        // Update the Player and UI state based on the current HP:
        for (int i = 0; i < PlayerHpUi.HeartsCollection.Length; i++) {
            
            // Swapping Sprite and Playing Effects:
            if (i < currentHp) {
                PlayerHpUi.HeartsCollection[i].sprite = PlayerHpUi.fullHPSprite;
            } else {
                PlayerHpUi.HeartsCollection[i].sprite = PlayerHpUi.lostHPSprite;
            }
        }
    }


    // heal when getting Hearts:
    public void IncreaseHp(int amount = 1) {

        if (currentHp < maxHp) {

            currentHp += amount;

        }

        // Safe-proof range:
        if (currentHp > maxHp) { currentHp = maxHp;}

        // Re-Draw the Hp Sprites after Healing:
        OnHealingHpUi();
    }

    void OnHealingHpUi() {
        // Update the Player and UI state based on the current HP:
        for (int i = 0; i < PlayerHpUi.HeartsCollection.Length; i++) {
            
            // Swapping Sprite and Playing Effects:
            if (i < currentHp) {
                PlayerHpUi.HeartsCollection[i].sprite = PlayerHpUi.fullHPSprite;
            } else {
                PlayerHpUi.HeartsCollection[i].sprite = PlayerHpUi.lostHPSprite;
            }
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

    // Invincible for fixed amount of frames:
    IEnumerator Invincible() {
        
        isInvin = true;

        yield return new WaitForSeconds(invinTime);

        isInvin = false;
    }

}

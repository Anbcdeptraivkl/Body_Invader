using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Coins's 2D Movement and On player contact effects Behaviours after spawning (droped!):
public class CoinBehaviour : MonoBehaviour
{
    public uint coinValue = 1;
    // Movement amplifying rate:
    public float speed = 10f;

    // References:
    Transform target;
    DropBehaviour dropAct;
    MoneyManager moneyManager;
    Rigidbody2D rgbd;


    void Start() {
        // Properties
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        dropAct = gameObject.GetComponent<DropBehaviour>();
        // Money
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        if (gameControllerObj) {
            moneyManager = gameControllerObj.GetComponent<MoneyManager>();
        }
    }

    void FixedUpdate() {
        // Burst > Still > Homing!
        if (dropAct.DoneBursting()) {
            MoveTowardPlayer();
        }
    }

    // Player getting coins:
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerReceive(other);
            Destroy(gameObject);
        }
    }

    void MoveTowardPlayer() {
        // Homing toward player using Transform
        GameObject player = GameObject.FindWithTag("Player");
        if (player) {
            target = player.transform;
            if (target) {
                Vector2 direction = (target.position - transform.position).normalized;
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            }   
        }
    }

    void PlayerReceive(Collider2D player) {
        // Coin manager process:
        moneyManager.IncreaseCurrent((int)coinValue);
        // Play Special Visual + Audio Effects:
        PlayEffects();
    }

    void PlayEffects() {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvincibllity : MonoBehaviour
{
    public float timer = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        Invincible();
        Invoke("StopInvin", timer);
    }

    void Invincible() {
        //Disable the Collider == no damage taken:
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    void StopInvin() {
        //Stop being invin:
        GetComponent<CapsuleCollider2D>().enabled = true;

    }
}

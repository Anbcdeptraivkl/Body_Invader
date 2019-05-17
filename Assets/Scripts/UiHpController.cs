using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHpController: MonoBehaviour {

    public GameObject hp1;
    public GameObject hp2;

    public GameObject hp3;


   
    void Start() {
        
    }

    //Lose HP Effects: Depleting, changing colors, and finally disable the Hp segments:
    public void Lose1() {
        hp1.GetComponent<Animator>().SetTrigger("Hit1");
    }

    public void Lose2() {
        // Deplete HP2, then play HP3 Danger animation:
        hp2.GetComponent<Animator>().SetTrigger("Hit2");
        
        Invoke("Flashing3", 0.5f);
    }

    public void Flashing3() {
        hp3.GetComponent<Animator>().enabled = true;
    }


}
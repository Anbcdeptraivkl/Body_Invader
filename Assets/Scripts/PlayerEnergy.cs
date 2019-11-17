using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    public Image fillEnergyBar;

    // The max Energy Value
    public float maxEnergy = 100;
    // Time for the Enrgy to deplete
    public float depleteRate = 1f;

    [SerializeField]
    private float nextRate = 0.1f;
    private float nextTime = 0f;
    static int currentEnergy;

    // Start is called before the first frame update
    void Start() {
        currentEnergy = (int)maxEnergy;
    }

    // Update is called once per frame
    void Update() {   
        // Set Fill Bar
        fillEnergyBar.fillAmount = Mathf.Lerp(fillEnergyBar.fillAmount, currentEnergy / maxEnergy, depleteRate * Time.deltaTime);
    }

    public bool SufficientEnergy(int amount) {
        if (currentEnergy >= amount)
            return true;
        else {
            ResponseWhenInsufficient();
            return false;
        }
    }

    public void DepleteEnergy(int amount) {
            currentEnergy -= amount;
            Debug.Log(currentEnergy / maxEnergy);
    }

    public void RefillEnergy(int amount) {
        if (currentEnergy < maxEnergy) {
            currentEnergy += amount;
        } else {
            Debug.Log("Full Energy already!");
        }
    }

    // Testing fot Input
    void Debug_EnergyInputHandler() {
        // Deplete
         if (Input.GetKeyDown(KeyCode.E) && Time.time > nextTime) {
            // Increase for the New Countdown
            nextTime = Time.time + nextRate;
            DepleteEnergy(10);
        } else if (Input.GetKeyDown(KeyCode.R) && Time.time > nextTime) {
            nextTime = Time.time + nextRate;
            RefillEnergy(10);
        }
    }

    void ResponseWhenInsufficient() {
        // 
        Debug.Log("Insufficient Energy!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPManager : MonoBehaviour
{
    public int baseHP;

    float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = Mathf.Abs(baseHP);
    }

    public void DecreaseHP(float value = 1) {
        currentHP -= value;
    }

    public void IncreaseHP(float value = 1) {
        currentHP += value;
    }

    public float GetCurrentHP() {
        return currentHP;
    }

    public bool Alive () {
        if (currentHP > 0) {
            return true;
        }
        else
        {
            return false;
        }
    }
}

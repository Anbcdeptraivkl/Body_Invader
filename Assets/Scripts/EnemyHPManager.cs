using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPManager : MonoBehaviour
{
    public int baseHP;

    int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = Mathf.Abs(baseHP);
    }

    public void DecreaseHP(int value = 1) {
        currentHP--;
    }

    public void IncreaseHP(int value = 1) {
        currentHP++;
    }

    public int GetCurrentHP() {
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

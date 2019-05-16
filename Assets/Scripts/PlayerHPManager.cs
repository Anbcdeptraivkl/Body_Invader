using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    [SerializeField]
    private int baseHp;

    int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = baseHp;
    }

    public void DecreaseHp(int amount) {
        currentHp -= amount;
    }

    public void IncreaseHp(int amount) {
        currentHp += amount;
    }

    public int CurrentHp() {
        return currentHp;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* PLAYER CONFIGS */
[System.Serializable]
public struct MovementBounds {
    public float x;
    public float y;
}

[System.Serializable]
public struct DashConfigs {
    public float distance;
    public float cooldown;
    public int cost;
    public float speed;
}

[System.Serializable]
public struct ShieldConfigs {
    public float duration;
    public float cooldown;
    public int cost;
}

[System.Serializable]
public class PlayerConfigs {
    public float fireRate;
    public float moveSpeed;
    public float moveRate;

    public MovementBounds movementBounds;
    public DashConfigs dash;
    public ShieldConfigs shield;
    public float enDepleteRate;
    public float enNextRate;
    public float invincibleTime;
    public int maxHp;
}

/* ENEMIES CONFIGS */
[System.Serializable]
public class EnemyConfigs {
    public int baseHp;
    public int enReward;
    public float invincibleTimer;
    public int dropChance;
}
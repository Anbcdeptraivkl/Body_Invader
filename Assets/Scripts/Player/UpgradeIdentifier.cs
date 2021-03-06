﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Identify the types of Upgrades that are going to be apply to the player:
// Component for Upgrade Prefabs: (Upgrades are different from Support Items)

// The Types:
public enum UpgradeType {
    StrongShot,
    Heart,
    Missile,
    None
}

public class UpgradeIdentifier : MonoBehaviour
{
    [SerializeField]
    UpgradeType upgradeType = UpgradeType.None;

    public UpgradeType GetUpgradeType() {
        return upgradeType;
    }
}
